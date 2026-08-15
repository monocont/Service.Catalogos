using Service.Catalogos.Application.DTOs.TipoCambio;

namespace Service.Catalogos.Application.Interfaces;

public interface ITipoCambioProveedor
{
    string MonedaOrigen { get; }
    string MonedaDestino { get; }
    Task<List<TipoCambioConsultaDto>> ObtenerPorMesAsync(int anio, int mes, CancellationToken cancellationToken);
}
