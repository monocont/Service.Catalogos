using MediatR;
using Service.Catalogos.Application.DTOs.TipoCp;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.TipoCp.ObtenerTiposCp;

public class ObtenerTiposCpQueryHandler : IRequestHandler<ObtenerTiposCpQuery, List<TipoCpDTO>>
{
    private readonly ITipoCpRepository _repositorio;

    public ObtenerTiposCpQueryHandler(ITipoCpRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<TipoCpDTO>> Handle(ObtenerTiposCpQuery request, CancellationToken cancellationToken)
    {
        var tipos = await _repositorio.ObtenerTiposCpAsync(cancellationToken);

        return tipos.Select(t => new TipoCpDTO
        {
            Codigo = t.Codigo,
            Nombre = t.Nombre,
            Naturaleza = t.Naturaleza,
            AplicaA = t.AplicaA,
            Signo = t.Signo
        }).ToList();
    }
}
