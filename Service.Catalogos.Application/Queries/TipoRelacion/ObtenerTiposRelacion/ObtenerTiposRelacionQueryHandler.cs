using MediatR;
using Service.Catalogos.Application.DTOs.TipoRelacion;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.TipoRelacion.ObtenerTiposRelacion;

public class ObtenerTiposRelacionQueryHandler : IRequestHandler<ObtenerTiposRelacionQuery, List<TipoRelacionDTO>>
{
    private readonly ITipoRelacionRepository _repositorio;

    public ObtenerTiposRelacionQueryHandler(ITipoRelacionRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<TipoRelacionDTO>> Handle(ObtenerTiposRelacionQuery request, CancellationToken cancellationToken)
    {
        var tipos = await _repositorio.ObtenerTiposRelacionAsync(cancellationToken);

        return tipos.Select(t => new TipoRelacionDTO
        {
            Codigo = t.Codigo,
            Descripcion = t.Descripcion
        }).ToList();
    }
}
