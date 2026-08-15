using MediatR;
using Service.Catalogos.Application.DTOs.ProyectoInversion;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.ProyectoInversion.ObtenerProyectosInversion;

public class ObtenerProyectosInversionQueryHandler : IRequestHandler<ObtenerProyectosInversionQuery, List<ProyectoInversionDTO>>
{
    private readonly IProyectoInversionRepository _repositorio;

    public ObtenerProyectosInversionQueryHandler(IProyectoInversionRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<ProyectoInversionDTO>> Handle(ObtenerProyectosInversionQuery request, CancellationToken cancellationToken)
    {
        var proyectos = await _repositorio.ObtenerProyectosInversionAsync(cancellationToken);

        return proyectos.Select(p => new ProyectoInversionDTO
        {
            Codigo = p.Codigo,
            Descripcion = p.Descripcion,
            Activo = p.Activo
        }).ToList();
    }
}
