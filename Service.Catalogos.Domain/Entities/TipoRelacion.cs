namespace Service.Catalogos.Domain.Entities;

public class TipoRelacion
{
    public string Codigo { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;

    private TipoRelacion() { }

    public static TipoRelacion Crear(string codigo, string descripcion)
    {
        return new TipoRelacion
        {
            Codigo = codigo,
            Descripcion = descripcion
        };
    }
}
