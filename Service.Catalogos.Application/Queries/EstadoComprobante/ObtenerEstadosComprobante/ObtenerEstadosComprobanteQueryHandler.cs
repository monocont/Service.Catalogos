using MediatR;
using Service.Catalogos.Application.DTOs.EstadoComprobante;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.EstadoComprobante.ObtenerEstadosComprobante;

public class ObtenerEstadosComprobanteQueryHandler : IRequestHandler<ObtenerEstadosComprobanteQuery, List<EstadoComprobanteDTO>>
{
    private readonly IEstadoComprobanteRepository _repositorio;

    public ObtenerEstadosComprobanteQueryHandler(IEstadoComprobanteRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<EstadoComprobanteDTO>> Handle(ObtenerEstadosComprobanteQuery request, CancellationToken cancellationToken)
    {
        var estados = await _repositorio.ObtenerEstadosComprobanteAsync(cancellationToken);

        return estados.Select(e => new EstadoComprobanteDTO
        {
            Codigo = e.Codigo,
            Nombre = e.Nombre,
            Descripcion = e.Descripcion,
            AfectaIgv = e.AfectaIgv
        }).ToList();
    }
}
