namespace Service.Catalogos.Application.DTOs.TipoDocIdentidad;

public class TipoDocIdentidadDTO
{
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public byte LongitudMin { get; set; }
    public byte LongitudMax { get; set; }
    public bool EsRuc { get; set; }
}
