using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface IDetraccionServicioRepository
{
    Task<List<DetraccionServicio>> ObtenerDetraccionesServicioAsync(CancellationToken cancellationToken);
}
