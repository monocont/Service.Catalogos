using MediatR;
using Service.Catalogos.Application.DTOs.TipoCambio;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.TipoCambio.ObtenerPorMes;

public class ObtenerTipoCambioPorMesQueryHandler : IRequestHandler<ObtenerTipoCambioPorMesQuery, List<ObtenerTipoCambioDTO>>
{
    private readonly ITipoCambioRepository _repositorio;

    public ObtenerTipoCambioPorMesQueryHandler(ITipoCambioRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<ObtenerTipoCambioDTO>> Handle(ObtenerTipoCambioPorMesQuery request, CancellationToken cancellationToken)
    {
        var fechaDesde = new DateTime(request.Anio, request.Mes, 1);
        var fechaHasta = fechaDesde.AddMonths(1).AddDays(-1);

        var tipoCambio = await _repositorio.ObtenerPorMonedaOrigenAsync(
            request.MonedaOrigen,
            fechaDesde,
            fechaHasta,
            cancellationToken);

        return tipoCambio
            .OrderBy(t => t.Fecha)
            .Select(t => new ObtenerTipoCambioDTO
            {
                CodigoMonedaOrigen = t.CodigoMonedaOrigen,
                CodigoMonedaDestino = t.CodigoMonedaDestino,
                Fecha = t.Fecha,
                PrecioCompra = t.PrecioCompra,
                PrecioVenta = t.PrecioVenta
            })
            .ToList();
    }
}
