using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Infrastructure.Services;

public class TipoCambioProveedorFactory : ITipoCambioProveedorFactory
{
    private readonly IEnumerable<ITipoCambioProveedor> _proveedores;

    public TipoCambioProveedorFactory(IEnumerable<ITipoCambioProveedor> proveedores)
    {
        _proveedores = proveedores;
    }

    public ITipoCambioProveedor? ObtenerProveedor(string monedaOrigen, string monedaDestino)
    {
        return _proveedores.FirstOrDefault(p =>
            p.MonedaOrigen == monedaOrigen &&
            p.MonedaDestino == monedaDestino);
    }
}
