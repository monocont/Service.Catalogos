using MediatR;
using Service.Catalogos.Application.DTOs.Ubigeo;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.Ubigeo.ObtenerProvincias;

public class ObtenerProvinciasQueryHandler : IRequestHandler<ObtenerProvinciasQuery, List<ProvinciaDTO>>
{
    private readonly IUbigeoRepository _repositorio;

    public ObtenerProvinciasQueryHandler(IUbigeoRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<ProvinciaDTO>> Handle(ObtenerProvinciasQuery request, CancellationToken cancellationToken)
    {
        var provincias = await _repositorio.ObtenerProvinciasAsync(request.CodigoDepartamento, cancellationToken);

        return provincias.Select(u => new ProvinciaDTO
        {
            CodigoUbigeo = u.CodigoUbigeo,
            CodigoProvincia = u.CodigoProvincia!,
            Provincia = u.Provincia!
        }).ToList();
    }
}