namespace Service.Catalogos.Domain.Entities;

public class DetraccionServicio : EntidadAuditoria
{
    public string Codigo { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public decimal Porcentaje { get; private set; }
    public char BienServicio { get; private set; }
    public DateTime FechaVigencia { get; private set; }

    private DetraccionServicio() { }

    public static DetraccionServicio Crear(
        string codigo,
        string descripcion,
        decimal porcentaje,
        char bienServicio,
        DateTime fechaVigencia,
        string usuarioCreacion)
    {
        return new DetraccionServicio
        {
            Codigo = codigo,
            Descripcion = descripcion,
            Porcentaje = porcentaje,
            BienServicio = bienServicio,
            FechaVigencia = fechaVigencia,
            Activo = true,
            FechaCreacion = DateTime.UtcNow,
            CreadoPor = usuarioCreacion
        };
    }
}
