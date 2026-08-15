using MediatR;
using Service.Catalogos.Application.DTOs.Ubigeo;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.Ubigeo.ObtenerDistritos;

public class ObtenerDistritosQueryHandler : IRequestHandler<ObtenerDistritosQuery, List<DistritoDTO>>
{
    private readonly IUbigeoRepository _repositorio;

    public ObtenerDistritosQueryHandler(IUbigeoRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<DistritoDTO>> Handle(ObtenerDistritosQuery request, CancellationToken cancellationToken)
    {
        var distritos = await _repositorio.ObtenerDistritosAsync(request.CodigoProvincia, cancellationToken);

        return distritos.Select(u => new DistritoDTO
        {
            CodigoUbigeo = u.CodigoUbigeo,
            CodigoDistrito = u.CodigoDistrito!,
            Distrito = u.Distrito!
        }).ToList();
    }
}