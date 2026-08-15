namespace Service.Catalogos.Domain.Entities;

public class Moneda
{
    public string CodigoIso { get; private set; } = string.Empty;
    public string Nombre { get; private set; } = string.Empty;
    public string Simbolo { get; private set; } = string.Empty;
    public bool EsMonedaNacional { get; private set; }

    private Moneda() { }

    public static Moneda Crear(
        string codigoIso,
        string nombre,
        string simbolo,
        bool esMonedaNacional)
    {
        return new Moneda
        {
            CodigoIso = codigoIso,
            Nombre = nombre,
            Simbolo = simbolo,
            EsMonedaNacional = esMonedaNacional
        };
    }
}