using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface ITipoRelacionRepository
{
    Task<List<TipoRelacion>> ObtenerTiposRelacionAsync(CancellationToken cancellationToken);
}
