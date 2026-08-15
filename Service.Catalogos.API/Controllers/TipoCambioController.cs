using System.Globalization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Commands.TipoCambio.LlenarDiario;
using Service.Catalogos.Application.Commands.TipoCambio.LlenarMasivo;
using Service.Catalogos.Application.Queries.TipoCambio.ObtenerPorMes;
using Service.Catalogos.Application.Queries.TipoCambio.ObtenerTipoCambio;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/tipo-cambio")]
public class TipoCambioController : ControllerBase
{
    private readonly IMediator _mediator;

    public TipoCambioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTipoCambio(
        [FromQuery] string codigoMonedaOrigen,
        [FromQuery] string fecha,
        CancellationToken cancellationToken)
    {
        if (!DateTime.TryParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fechaParsed))
        {
            throw new ArgumentException("El formato de la fecha debe ser dd/MM/yyyy.");
        }

        var query = new ObtenerTipoCambioQuery(codigoMonedaOrigen, fechaParsed);
        var resultado = await _mediator.Send(query, cancellationToken);
        
        return Ok(resultado);
    }

    [HttpGet("por-mes")]
    public async Task<IActionResult> ObtenerTipoCambioPorMes(
        [FromQuery] string monedaOrigen,
        [FromQuery] int anio,
        [FromQuery] int mes,
        CancellationToken cancellationToken)
    {
        var query = new ObtenerTipoCambioPorMesQuery(monedaOrigen, anio, mes);
        var resultado = await _mediator.Send(query, cancellationToken);
        
        return Ok(resultado);
    }

    [HttpPost("diario")]
    public async Task<IActionResult> LlenarDiario(CancellationToken cancellationToken)
    {
        var usuario = User.Identity?.Name ?? "INVITADO";
        var resultado = await _mediator.Send(new LlenarTipoCambioDiarioCommand(usuario), cancellationToken);
        
        return Ok(resultado);
    }

    [HttpPost("masivo")]
    public async Task<IActionResult> LlenarMasivo(
        [FromQuery] int anio,
        [FromQuery] int mes,
        CancellationToken cancellationToken)
    {
        var usuario = User.Identity?.Name ?? "INVITADO";
        var comando = new LlenarTipoCambioMasivoCommand(anio, mes, usuario, "USD", "PEN");
        var resultado = await _mediator.Send(comando, cancellationToken);
        
        return Ok(resultado);
    }
}