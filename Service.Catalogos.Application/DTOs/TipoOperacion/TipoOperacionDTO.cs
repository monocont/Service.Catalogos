namespace Service.Catalogos.Application.DTOs.TipoOperacion;

public class TipoOperacionDTO
{
    public string Codigo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public bool EsExportacion { get; set; }
    public bool EsDetraccion { get; set; }
    public bool EsPercepcion { get; set; }
}
