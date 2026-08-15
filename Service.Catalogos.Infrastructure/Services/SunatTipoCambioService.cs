using Microsoft.Extensions.Configuration;
using Service.Catalogos.Application.DTOs.TipoCambio;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Infrastructure.Services;

public class SunatTipoCambioService : ISunatTipoCambioService
{
    private readonly HttpClient _httpClient;
    private readonly string _url;

    public SunatTipoCambioService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _url = configuration["SunatTipoCambio:Url"] ?? "https://www.sunat.gob.pe/a/txt/tipoCambio.txt";
    }

    public async Task<TipoCambioConsultaDto?> ObtenerDelDiaAsync(CancellationToken cancellationToken)
    {
        var respuesta = await _httpClient.GetStringAsync(_url, cancellationToken);

        if (string.IsNullOrWhiteSpace(respuesta))
        {
            return null;
        }

        var partes = respuesta.Split('|', StringSplitOptions.TrimEntries);

        if (partes.Length < 3 ||
            !DateTime.TryParseExact(partes[0], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var fecha) ||
            !TryParseDecimal(partes[1], out var precioCompra) ||
            !TryParseDecimal(partes[2], out var precioVenta))
        {
            return null;
        }

        return new TipoCambioConsultaDto
        {
            Fecha = fecha,
            PrecioCompra = precioCompra,
            PrecioVenta = precioVenta
        };
    }

    private static bool TryParseDecimal(string valor, out decimal resultado)
    {
        valor = valor.Replace(',', '.');
        return decimal.TryParse(valor, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out resultado);
    }
}
