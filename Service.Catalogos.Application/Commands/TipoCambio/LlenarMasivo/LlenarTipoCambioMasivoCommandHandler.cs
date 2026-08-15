using MediatR;
using Service.Catalogos.Application.Interfaces;
using TipoCambioEntity = Service.Catalogos.Domain.Entities.TipoCambio;

namespace Service.Catalogos.Application.Commands.TipoCambio.LlenarMasivo;

public class LlenarTipoCambioMasivoCommandHandler : IRequestHandler<LlenarTipoCambioMasivoCommand, bool>
{
    private static readonly TimeZoneInfo ZonaPeru = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");

    private readonly ITipoCambioProveedorFactory _proveedorFactory;
    private readonly ITipoCambioRepository _repositorio;

    public LlenarTipoCambioMasivoCommandHandler(
        ITipoCambioProveedorFactory proveedorFactory,
        ITipoCambioRepository repositorio)
    {
        _proveedorFactory = proveedorFactory;
        _repositorio = repositorio;
    }

    public async Task<bool> Handle(LlenarTipoCambioMasivoCommand request, CancellationToken cancellationToken)
    {
        var proveedor = _proveedorFactory.ObtenerProveedor(request.MonedaOrigen, request.MonedaDestino);

        if (proveedor is null)
        {
            return false;
        }

        var fechaDesde = new DateTime(request.Anio, request.Mes, 1);
        var fechaHasta = fechaDesde.AddMonths(1).AddDays(-1);

        var hoy = TimeZoneInfo.ConvertTime(DateTime.UtcNow, ZonaPeru);
        if (request.Anio == hoy.Year && request.Mes == hoy.Month)
        {
            fechaHasta = hoy.Date;
        }

        var diasExistentes = await _repositorio.ObtenerFechasConDatosAsync(
            request.MonedaOrigen,
            request.MonedaDestino,
            fechaDesde,
            fechaHasta,
            cancellationToken);

        if (diasExistentes.Count > 0)
        {
            if (request.Anio < hoy.Year)
            {
                return true;
            }

            if (CalcularDiasFaltantes(fechaDesde, fechaHasta, diasExistentes).Count == 0)
            {
                return true;
            }
        }

        var datosMes = await proveedor.ObtenerPorMesAsync(request.Anio, request.Mes, cancellationToken);

        var existentes = diasExistentes.ToHashSet();

        foreach (var dato in datosMes.Where(d => !existentes.Contains(d.Fecha)))
        {
            var nuevo = TipoCambioEntity.Crear(
                request.MonedaOrigen,
                request.MonedaDestino,
                dato.Fecha,
                dato.PrecioCompra,
                dato.PrecioVenta,
                request.Usuario);

            await _repositorio.InsertarAsync(nuevo, cancellationToken);
        }

        await _repositorio.CommitAsync();

        return true;
    }

    private static List<DateTime> CalcularDiasFaltantes(
        DateTime fechaDesde,
        DateTime fechaHasta,
        List<DateTime> diasExistentes)
    {
        var existentes = diasExistentes.ToHashSet();
        var faltantes = new List<DateTime>();

        for (var dia = fechaDesde; dia <= fechaHasta; dia = dia.AddDays(1))
        {
            if (!existentes.Contains(dia))
            {
                faltantes.Add(dia);
            }
        }

        return faltantes;
    }
}
