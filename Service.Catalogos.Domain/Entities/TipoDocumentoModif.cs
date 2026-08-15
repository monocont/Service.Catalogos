namespace Service.Catalogos.Domain.Entities;

public class TipoDocumentoModif
{
    public string Codigo { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;

    private TipoDocumentoModif() { }

    public static TipoDocumentoModif Crear(string codigo, string descripcion)
    {
        return new TipoDocumentoModif
        {
            Codigo = codigo,
            Descripcion = descripcion
        };
    }
}
