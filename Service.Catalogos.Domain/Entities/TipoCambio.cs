namespace Service.Catalogos.Domain.Entities;

public class TipoCambio : EntidadAuditoria
{
    public string CodigoMonedaOrigen { get; private set; } = string.Empty;
    public string CodigoMonedaDestino { get; private set; } = string.Empty;
    public DateTime Fecha { get; private set; }
    public decimal PrecioCompra { get; private set; }
    public decimal PrecioVenta { get; private set; }

    private TipoCambio() { }

    public static TipoCambio Crear(
        string codigoMonedaOrigen,
        string codigoMonedaDestino,
        DateTime fecha,
        decimal precioCompra,
        decimal precioVenta,
        string usuarioCreacion)
    {
        return new TipoCambio
        {
            CodigoMonedaOrigen = codigoMonedaOrigen,
            CodigoMonedaDestino = codigoMonedaDestino,
            Fecha = fecha,
            PrecioCompra = precioCompra,
            PrecioVenta = precioVenta,
            Activo = true,
            FechaCreacion = DateTime.UtcNow,
            CreadoPor = usuarioCreacion
        };
    }

    public void Actualizar(decimal precioCompra, decimal precioVenta, string usuarioModificacion)
    {
        PrecioCompra = precioCompra;
        PrecioVenta = precioVenta;
        ModificadoPor = usuarioModificacion;
        FechaModificacion = DateTime.UtcNow;
    }
}