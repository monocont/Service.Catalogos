using MediatR;
using Service.Catalogos.Application.DTOs.TipoCambio;

namespace Service.Catalogos.Application.Queries.TipoCambio.ObtenerPorMes;

public class ObtenerTipoCambioPorMesQuery : IRequest<List<ObtenerTipoCambioDTO>>
{
    public string MonedaOrigen { get; }
    public int Anio { get; }
    public int Mes { get; }

    public ObtenerTipoCambioPorMesQuery(string monedaOrigen, int anio, int mes)
    {
        MonedaOrigen = monedaOrigen;
        Anio = anio;
        Mes = mes;
    }
}
