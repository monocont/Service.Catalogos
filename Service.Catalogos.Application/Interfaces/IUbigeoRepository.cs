using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface IUbigeoRepository
{
    Task<List<Ubigeo>> ObtenerDepartamentosAsync(CancellationToken cancellationToken);
    Task<List<Ubigeo>> ObtenerProvinciasAsync(string codigoDepartamento, CancellationToken cancellationToken);
    Task<List<Ubigeo>> ObtenerDistritosAsync(string codigoProvincia, CancellationToken cancellationToken);
    Task CommitAsync();
}