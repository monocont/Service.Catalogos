using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface IClasifBssSssRepository
{
    Task<List<ClasifBssSss>> ObtenerClasificacionesBssSssAsync(CancellationToken cancellationToken);
}
