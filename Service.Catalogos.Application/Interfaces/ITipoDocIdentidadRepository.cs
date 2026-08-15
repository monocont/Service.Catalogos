using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface ITipoDocIdentidadRepository
{
    Task<List<TipoDocIdentidad>> ObtenerTiposDocIdentidadAsync(CancellationToken cancellationToken);
}
