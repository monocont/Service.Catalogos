using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface ITipoCpRepository
{
    Task<List<TipoCp>> ObtenerTiposCpAsync(CancellationToken cancellationToken);
}
