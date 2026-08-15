namespace Service.Catalogos.Application.DTOs.TipoCp;

public class TipoCpDTO
{
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public char Naturaleza { get; set; }
    public string? AplicaA { get; set; }
    public char Signo { get; set; }
}
