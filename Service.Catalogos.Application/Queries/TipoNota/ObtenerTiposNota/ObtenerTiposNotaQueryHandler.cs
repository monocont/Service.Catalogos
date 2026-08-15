using MediatR;
using Service.Catalogos.Application.DTOs.TipoNota;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.TipoNota.ObtenerTiposNota;

public class ObtenerTiposNotaQueryHandler : IRequestHandler<ObtenerTiposNotaQuery, List<TipoNotaDTO>>
{
    private readonly ITipoNotaRepository _repositorio;

    public ObtenerTiposNotaQueryHandler(ITipoNotaRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<TipoNotaDTO>> Handle(ObtenerTiposNotaQuery request, CancellationToken cancellationToken)
    {
        var tipos = await _repositorio.ObtenerTiposNotaAsync(cancellationToken);

        return tipos.Select(t => new TipoNotaDTO
        {
            Codigo = t.Codigo,
            Descripcion = t.Descripcion,
            AplicaA = t.AplicaA,
            Signo = t.Signo
        }).ToList();
    }
}
