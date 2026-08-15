using MediatR;
using Service.Catalogos.Application.DTOs.ClasifBssSss;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.ClasifBssSss.ObtenerClasifBssSss;

public class ObtenerClasifBssSssQueryHandler : IRequestHandler<ObtenerClasifBssSssQuery, List<ClasifBssSssDTO>>
{
    private readonly IClasifBssSssRepository _repositorio;

    public ObtenerClasifBssSssQueryHandler(IClasifBssSssRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<ClasifBssSssDTO>> Handle(ObtenerClasifBssSssQuery request, CancellationToken cancellationToken)
    {
        var clasif = await _repositorio.ObtenerClasificacionesBssSssAsync(cancellationToken);

        return clasif.Select(c => new ClasifBssSssDTO
        {
            Codigo = c.Codigo,
            Nombre = c.Nombre,
            Descripcion = c.Descripcion
        }).ToList();
    }
}
