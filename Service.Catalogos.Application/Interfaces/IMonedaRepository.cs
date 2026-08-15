using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface IMonedaRepository
{
    Task<List<Moneda>> ObtenerMonedasAsync(CancellationToken cancellationToken);
}