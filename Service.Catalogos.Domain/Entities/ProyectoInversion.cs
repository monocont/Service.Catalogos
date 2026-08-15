namespace Service.Catalogos.Domain.Entities;

public class ProyectoInversion : EntidadAuditoria
{
    public string Codigo { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;

    private ProyectoInversion() { }

    public static ProyectoInversion Crear(string codigo, string descripcion, string usuarioCreacion)
    {
        return new ProyectoInversion
        {
            Codigo = codigo,
            Descripcion = descripcion,
            Activo = true,
            FechaCreacion = DateTime.UtcNow,
            CreadoPor = usuarioCreacion
        };
    }
}
