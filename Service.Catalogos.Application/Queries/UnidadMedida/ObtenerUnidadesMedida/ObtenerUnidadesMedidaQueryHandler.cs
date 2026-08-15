using MediatR;
using Service.Catalogos.Application.DTOs.UnidadMedida;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.UnidadMedida.ObtenerUnidadesMedida;

public class ObtenerUnidadesMedidaQueryHandler : IRequestHandler<ObtenerUnidadesMedidaQuery, List<UnidadMedidaDTO>>
{
    private readonly IUnidadMedidaRepository _repositorio;

    public ObtenerUnidadesMedidaQueryHandler(IUnidadMedidaRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<UnidadMedidaDTO>> Handle(ObtenerUnidadesMedidaQuery request, CancellationToken cancellationToken)
    {
        var unidades = await _repositorio.ObtenerUnidadesMedidaAsync(cancellationToken);

        return unidades.Select(u => new UnidadMedidaDTO
        {
            Codigo = u.Codigo,
            Nombre = u.Nombre
        }).ToList();
    }
}
