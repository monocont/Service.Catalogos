using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface ITipoDocumentoModifRepository
{
    Task<List<TipoDocumentoModif>> ObtenerTiposDocumentoModifAsync(CancellationToken cancellationToken);
}
