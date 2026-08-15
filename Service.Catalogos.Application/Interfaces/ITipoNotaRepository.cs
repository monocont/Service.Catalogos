using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface ITipoNotaRepository
{
    Task<List<TipoNota>> ObtenerTiposNotaAsync(CancellationToken cancellationToken);
}
