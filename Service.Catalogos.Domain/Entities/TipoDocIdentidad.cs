namespace Service.Catalogos.Domain.Entities;

public class TipoDocIdentidad
{
    public string Codigo { get; private set; } = string.Empty;
    public string Nombre { get; private set; } = string.Empty;
    public byte LongitudMin { get; private set; }
    public byte LongitudMax { get; private set; }
    public bool EsRuc { get; private set; }

    private TipoDocIdentidad() { }

    public static TipoDocIdentidad Crear(
        string codigo,
        string nombre,
        byte longitudMin,
        byte longitudMax,
        bool esRuc = false)
    {
        return new TipoDocIdentidad
        {
            Codigo = codigo,
            Nombre = nombre,
            LongitudMin = longitudMin,
            LongitudMax = longitudMax,
            EsRuc = esRuc
        };
    }
}
