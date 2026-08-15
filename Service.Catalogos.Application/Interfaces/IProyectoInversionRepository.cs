using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface IProyectoInversionRepository
{
    Task<List<ProyectoInversion>> ObtenerProyectosInversionAsync(CancellationToken cancellationToken);
}
