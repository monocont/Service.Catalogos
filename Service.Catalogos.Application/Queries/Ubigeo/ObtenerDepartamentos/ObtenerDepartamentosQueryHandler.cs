using MediatR;
using Service.Catalogos.Application.DTOs.Ubigeo;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.Ubigeo.ObtenerDepartamentos;

public class ObtenerDepartamentosQueryHandler : IRequestHandler<ObtenerDepartamentosQuery, List<DepartamentoDTO>>
{
    private readonly IUbigeoRepository _repositorio;

    public ObtenerDepartamentosQueryHandler(IUbigeoRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<DepartamentoDTO>> Handle(ObtenerDepartamentosQuery request, CancellationToken cancellationToken)
    {
        var departamentos = await _repositorio.ObtenerDepartamentosAsync(cancellationToken);

        return departamentos.Select(u => new DepartamentoDTO
        {
            CodigoUbigeo = u.CodigoUbigeo,
            CodigoDepartamento = u.CodigoDepartamento,
            Departamento = u.Departamento
        }).ToList();
    }
}