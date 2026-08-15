namespace Service.Catalogos.Application.DTOs.TipoCambio;

public class ObtenerTipoCambioDTO
{
    public string CodigoMonedaOrigen { get; set; } = string.Empty;
    public string CodigoMonedaDestino { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public decimal PrecioCompra { get; set; }
    public decimal PrecioVenta { get; set; }
}