namespace Service.Catalogos.Domain.Entities;

public class EstadoComprobante
{
    public string Codigo { get; private set; } = string.Empty;
    public string Nombre { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public bool AfectaIgv { get; private set; } = true;

    private EstadoComprobante() { }

    public static EstadoComprobante Crear(string codigo, string nombre, string descripcion, bool afectaIgv = true)
    {
        return new EstadoComprobante
        {
            Codigo = codigo,
            Nombre = nombre,
            Descripcion = descripcion,
            AfectaIgv = afectaIgv
        };
    }
}
