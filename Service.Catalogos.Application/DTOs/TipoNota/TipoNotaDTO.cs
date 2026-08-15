namespace Service.Catalogos.Application.DTOs.TipoNota;

public class TipoNotaDTO
{
    public string Codigo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string AplicaA { get; set; } = string.Empty;
    public char Signo { get; set; }
}
