using MediatR;
using Service.Catalogos.Application.DTOs.TipoDocIdentidad;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.TipoDocIdentidad.ObtenerTiposDocIdentidad;

public class ObtenerTiposDocIdentidadQueryHandler : IRequestHandler<ObtenerTiposDocIdentidadQuery, List<TipoDocIdentidadDTO>>
{
    private readonly ITipoDocIdentidadRepository _repositorio;

    public ObtenerTiposDocIdentidadQueryHandler(ITipoDocIdentidadRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<TipoDocIdentidadDTO>> Handle(ObtenerTiposDocIdentidadQuery request, CancellationToken cancellationToken)
    {
        var tipos = await _repositorio.ObtenerTiposDocIdentidadAsync(cancellationToken);

        return tipos.Select(t => new TipoDocIdentidadDTO
        {
            Codigo = t.Codigo,
            Nombre = t.Nombre,
            LongitudMin = t.LongitudMin,
            LongitudMax = t.LongitudMax,
            EsRuc = t.EsRuc
        }).ToList();
    }
}
