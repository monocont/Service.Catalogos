using MediatR;
using Service.Catalogos.Application.DTOs.Moneda;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.Moneda.ObtenerMonedas;

public class ObtenerMonedasQueryHandler : IRequestHandler<ObtenerMonedasQuery, List<ObtenerMonedasDTO>>
{
    private readonly IMonedaRepository _repositorio;

    public ObtenerMonedasQueryHandler(IMonedaRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<ObtenerMonedasDTO>> Handle(ObtenerMonedasQuery request, CancellationToken cancellationToken)
    {
        var monedas = await _repositorio.ObtenerMonedasAsync(cancellationToken);

        return monedas.Select(m => new ObtenerMonedasDTO
        {
            CodigoIso = m.CodigoIso,
            Nombre = m.Nombre,
            Simbolo = m.Simbolo,
            EsMonedaNacional = m.EsMonedaNacional
        }).ToList();
    }
}