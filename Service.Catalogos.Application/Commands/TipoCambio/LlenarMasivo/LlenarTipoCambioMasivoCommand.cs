using MediatR;

namespace Service.Catalogos.Application.Commands.TipoCambio.LlenarMasivo;

public class LlenarTipoCambioMasivoCommand : IRequest<bool>
{
    public int Anio { get; }
    public int Mes { get; }
    public string Usuario { get; }
    public string MonedaOrigen { get; }
    public string MonedaDestino { get; }

    public LlenarTipoCambioMasivoCommand(
        int anio,
        int mes,
        string usuario,
        string monedaOrigen,
        string monedaDestino)
    {
        Anio = anio;
        Mes = mes;
        Usuario = usuario;
        MonedaOrigen = monedaOrigen;
        MonedaDestino = monedaDestino;
    }
}
