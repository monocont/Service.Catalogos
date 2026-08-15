namespace Service.Catalogos.Domain.Entities;

public class TipoNota
{
    public string Codigo { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public string AplicaA { get; private set; } = string.Empty;
    public char Signo { get; private set; }

    private TipoNota() { }

    public static TipoNota Crear(
        string codigo,
        string descripcion,
        string aplicaA,
        char signo = '-')
    {
        return new TipoNota
        {
            Codigo = codigo,
            Descripcion = descripcion,
            AplicaA = aplicaA,
            Signo = signo
        };
    }
}
