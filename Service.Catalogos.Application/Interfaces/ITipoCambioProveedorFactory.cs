namespace Service.Catalogos.Application.Interfaces;

public interface ITipoCambioProveedorFactory
{
    ITipoCambioProveedor? ObtenerProveedor(string monedaOrigen, string monedaDestino);
}
