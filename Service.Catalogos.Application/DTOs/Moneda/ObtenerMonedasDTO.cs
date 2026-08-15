namespace Service.Catalogos.Application.DTOs.Moneda;

public class ObtenerMonedasDTO
{
    public string CodigoIso { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Simbolo { get; set; } = string.Empty;
    public bool EsMonedaNacional { get; set; }
}