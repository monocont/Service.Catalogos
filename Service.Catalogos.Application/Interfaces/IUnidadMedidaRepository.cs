using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface IUnidadMedidaRepository
{
    Task<List<UnidadMedida>> ObtenerUnidadesMedidaAsync(CancellationToken cancellationToken);
}
