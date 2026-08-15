namespace Service.Catalogos.Domain.Entities;

public class ClasifBssSss
{
    public string Codigo { get; private set; } = string.Empty;
    public string Nombre { get; private set; } = string.Empty;
    public string? Descripcion { get; private set; }

    private ClasifBssSss() { }

    public static ClasifBssSss Crear(string codigo, string nombre, string? descripcion = null)
    {
        return new ClasifBssSss
        {
            Codigo = codigo,
            Nombre = nombre,
            Descripcion = descripcion
        };
    }
}
