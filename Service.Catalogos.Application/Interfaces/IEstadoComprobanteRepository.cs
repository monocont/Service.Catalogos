using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface IEstadoComprobanteRepository
{
    Task<List<EstadoComprobante>> ObtenerEstadosComprobanteAsync(CancellationToken cancellationToken);
}
