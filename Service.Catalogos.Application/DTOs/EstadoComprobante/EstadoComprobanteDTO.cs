namespace Service.Catalogos.Application.DTOs.EstadoComprobante;

public class EstadoComprobanteDTO
{
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public bool AfectaIgv { get; set; } = true;
}
