namespace Service.Catalogos.Domain.Entities;

public class TipoCp
{
    public string Codigo { get; private set; } = string.Empty;
    public string Nombre { get; private set; } = string.Empty;
    public char Naturaleza { get; private set; }
    public string? AplicaA { get; private set; }
    public char Signo { get; private set; }

    private TipoCp() { }

    public static TipoCp Crear(
        string codigo,
        string nombre,
        char naturaleza,
        string? aplicaA = null,
        char signo = '+')
    {
        return new TipoCp
        {
            Codigo = codigo,
            Nombre = nombre,
            Naturaleza = naturaleza,
            AplicaA = aplicaA,
            Signo = signo
        };
    }
}
