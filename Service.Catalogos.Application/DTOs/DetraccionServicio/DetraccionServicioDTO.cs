namespace Service.Catalogos.Application.DTOs.DetraccionServicio;

public class DetraccionServicioDTO
{
    public string Codigo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public decimal Porcentaje { get; set; }
    public char BienServicio { get; set; }
    public DateTime FechaVigencia { get; set; }
    public bool Activo { get; set; }
}
