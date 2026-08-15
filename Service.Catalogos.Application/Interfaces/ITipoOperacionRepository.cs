using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface ITipoOperacionRepository
{
    Task<List<TipoOperacion>> ObtenerTiposOperacionAsync(CancellationToken cancellationToken);
}
