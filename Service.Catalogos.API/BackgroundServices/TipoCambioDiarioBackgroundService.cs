using MediatR;
using Microsoft.Extensions.Configuration;
using Service.Catalogos.Application.Commands.TipoCambio.LlenarDiario;

namespace Service.Catalogos.API.BackgroundServices;

public class TipoCambioDiarioBackgroundService : BackgroundService
{
    private static readonly TimeZoneInfo ZonaPeru = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");

    private readonly TimeSpan _horaEjecucion;
    private readonly IMediator _mediator;
    private readonly ILogger<TipoCambioDiarioBackgroundService> _logger;

    public TipoCambioDiarioBackgroundService(
        IConfiguration configuration,
        IMediator mediator,
        ILogger<TipoCambioDiarioBackgroundService> logger)
    {
        var horaConfig = configuration["SunatTipoCambio:HoraEjecucion"] ?? "13:00:00";
        _horaEjecucion = TimeSpan.TryParse(horaConfig, out var hora)
            ? hora
            : TimeSpan.FromHours(13);

        _mediator = mediator;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var ahora = TimeZoneInfo.ConvertTime(DateTime.UtcNow, ZonaPeru);
                var proximaEjecucion = ahora.Date + _horaEjecucion;

                if (ahora >= proximaEjecucion)
                {
                    proximaEjecucion = proximaEjecucion.AddDays(1);
                }

                var delay = proximaEjecucion - ahora;
                _logger.LogInformation("Próxima ejecución del llenado diario de tipo de cambio: {Hora}", proximaEjecucion);

                await Task.Delay(delay, stoppingToken);
                stoppingToken.ThrowIfCancellationRequested();

                await _mediator.Send(new LlenarTipoCambioDiarioCommand("CORE"), stoppingToken);
                _logger.LogInformation("Llenado diario de tipo de cambio ejecutado por CORE");
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al ejecutar el llenado diario de tipo de cambio");
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
