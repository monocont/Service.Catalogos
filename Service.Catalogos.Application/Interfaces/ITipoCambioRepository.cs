using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Application.Interfaces;

public interface ITipoCambioRepository
{
    Task<List<TipoCambio>> ObtenerPorMonedaOrigenAsync(
        string codigoMonedaOrigen,
        DateTime? fechaDesde,
        DateTime? fechaHasta,
        CancellationToken cancellationToken);
    Task<TipoCambio?> ObtenerPorMonedaOrigenYFechaAsync(
        string codigoMonedaOrigen,
        DateTime fecha,
        CancellationToken cancellationToken);
    Task<TipoCambio?> ObtenerPorClaveAsync(
        string codigoMonedaOrigen,
        string codigoMonedaDestino,
        DateTime fecha,
        CancellationToken cancellationToken);
    Task<List<DateTime>> ObtenerFechasConDatosAsync(
        string codigoMonedaOrigen,
        string codigoMonedaDestino,
        DateTime fechaDesde,
        DateTime fechaHasta,
        CancellationToken cancellationToken);
    Task InsertarAsync(TipoCambio entity, CancellationToken cancellationToken);
    Task CommitAsync();
}