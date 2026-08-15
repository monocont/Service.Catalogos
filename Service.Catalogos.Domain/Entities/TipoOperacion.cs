namespace Service.Catalogos.Domain.Entities;

public class TipoOperacion
{
    public string Codigo { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public bool EsExportacion { get; private set; }
    public bool EsDetraccion { get; private set; }
    public bool EsPercepcion { get; private set; }

    private TipoOperacion() { }

    public static TipoOperacion Crear(
        string codigo,
        string descripcion,
        bool esExportacion = false,
        bool esDetraccion = false,
        bool esPercepcion = false)
    {
        return new TipoOperacion
        {
            Codigo = codigo,
            Descripcion = descripcion,
            EsExportacion = esExportacion,
            EsDetraccion = esDetraccion,
            EsPercepcion = esPercepcion
        };
    }
}
