using Service.Catalogos.Application.DTOs.TipoCambio;

namespace Service.Catalogos.Application.Interfaces;

public interface ISunatTipoCambioService
{
    Task<TipoCambioConsultaDto?> ObtenerDelDiaAsync(CancellationToken cancellationToken);
}
