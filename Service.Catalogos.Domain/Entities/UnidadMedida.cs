namespace Service.Catalogos.Domain.Entities;

public class UnidadMedida
{
    public string Codigo { get; private set; } = string.Empty;
    public string Nombre { get; private set; } = string.Empty;

    private UnidadMedida() { }

    public static UnidadMedida Crear(string codigo, string nombre)
    {
        return new UnidadMedida
        {
            Codigo = codigo,
            Nombre = nombre
        };
    }
}
