using MediatR;
using Service.Catalogos.Application.DTOs.TipoCambio;

namespace Service.Catalogos.Application.Queries.TipoCambio.ObtenerTipoCambio;

public class ObtenerTipoCambioQuery : IRequest<ObtenerTipoCambioDTO?>
{
    public string CodigoMonedaOrigen { get; }
    public DateTime Fecha { get; }

    public ObtenerTipoCambioQuery(string codigoMonedaOrigen, DateTime fecha)
    {
        CodigoMonedaOrigen = codigoMonedaOrigen;
        Fecha = fecha;
    }
}