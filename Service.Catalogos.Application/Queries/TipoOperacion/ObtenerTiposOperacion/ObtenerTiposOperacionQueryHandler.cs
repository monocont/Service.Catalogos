using MediatR;
using Service.Catalogos.Application.DTOs.TipoOperacion;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.TipoOperacion.ObtenerTiposOperacion;

public class ObtenerTiposOperacionQueryHandler : IRequestHandler<ObtenerTiposOperacionQuery, List<TipoOperacionDTO>>
{
    private readonly ITipoOperacionRepository _repositorio;

    public ObtenerTiposOperacionQueryHandler(ITipoOperacionRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<TipoOperacionDTO>> Handle(ObtenerTiposOperacionQuery request, CancellationToken cancellationToken)
    {
        var tipos = await _repositorio.ObtenerTiposOperacionAsync(cancellationToken);

        return tipos.Select(t => new TipoOperacionDTO
        {
            Codigo = t.Codigo,
            Descripcion = t.Descripcion,
            EsExportacion = t.EsExportacion,
            EsDetraccion = t.EsDetraccion,
            EsPercepcion = t.EsPercepcion
        }).ToList();
    }
}
