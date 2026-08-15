using MediatR;
using Service.Catalogos.Application.DTOs.TipoDocumentoModif;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.TipoDocumentoModif.ObtenerTiposDocumentoModif;

public class ObtenerTiposDocumentoModifQueryHandler : IRequestHandler<ObtenerTiposDocumentoModifQuery, List<TipoDocumentoModifDTO>>
{
    private readonly ITipoDocumentoModifRepository _repositorio;

    public ObtenerTiposDocumentoModifQueryHandler(ITipoDocumentoModifRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<TipoDocumentoModifDTO>> Handle(ObtenerTiposDocumentoModifQuery request, CancellationToken cancellationToken)
    {
        var tipos = await _repositorio.ObtenerTiposDocumentoModifAsync(cancellationToken);

        return tipos.Select(t => new TipoDocumentoModifDTO
        {
            Codigo = t.Codigo,
            Descripcion = t.Descripcion
        }).ToList();
    }
}
