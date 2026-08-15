using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Service.Catalogos.Application.DTOs.TipoCambio;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Infrastructure.Services;

public class SunatTipoCambioProveedor : ITipoCambioProveedor
{
    private readonly string _urlPagina;
    private readonly string _urlApi;

    public string MonedaOrigen => "USD";
    public string MonedaDestino => "PEN";

    public SunatTipoCambioProveedor(IConfiguration configuration)
    {
        _urlPagina = configuration["SunatTipoCambioMasivo:UrlPagina"]
            ?? "https://e-consulta.sunat.gob.pe/cl-at-ittipcam/tcS01Alias";
        _urlApi = configuration["SunatTipoCambioMasivo:UrlApi"]
            ?? "https://e-consulta.sunat.gob.pe/cl-at-ittipcam/tcS01Alias/listarTipoCambio";
    }

    public async Task<List<TipoCambioConsultaDto>> ObtenerPorMesAsync(int anio, int mes, CancellationToken cancellationToken)
    {
        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });

        try
        {
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync(_urlPagina, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
            await page.WaitForTimeoutAsync(3000);

            cancellationToken.ThrowIfCancellationRequested();

            var token = await page.EvaluateAsync<string>(
                "async () => await grecaptcha.execute(site_key_sunat, {action: 'token'})");

            var json = await page.EvaluateAsync<string>(
                "async (args) => {" +
                "  const resp = await fetch(args.url, {" +
                "    method: 'POST'," +
                "    headers: {'Content-Type': 'application/json'}," +
                "    body: JSON.stringify({ anio: args.anio, mes: args.mes, token: args.token })" +
                "  });" +
                "  return await resp.text();" +
                "}",
                new { url = _urlApi, anio, mes = mes - 1, token });

            return ParseRespuesta(json);
        }
        finally
        {
            await browser.CloseAsync();
        }
    }

    private static List<TipoCambioConsultaDto> ParseRespuesta(string json)
    {
        var resultado = new List<TipoCambioConsultaDto>();

        if (string.IsNullOrWhiteSpace(json))
        {
            return resultado;
        }

        using var documento = JsonDocument.Parse(json);

        if (documento.RootElement.ValueKind != JsonValueKind.Array)
        {
            return resultado;
        }

        var agrupados = documento.RootElement.EnumerateArray()
            .Where(item => item.TryGetProperty("codTipo", out _))
            .GroupBy(item => item.GetProperty("fecPublica").GetString() ?? string.Empty)
            .Where(grupo => !string.IsNullOrEmpty(grupo.Key));

        foreach (var grupo in agrupados)
        {
            if (!DateTime.TryParseExact(grupo.Key, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var fecha))
            {
                continue;
            }

            var compraItem = grupo.FirstOrDefault(i => i.GetProperty("codTipo").GetString() == "C");
            var ventaItem = grupo.FirstOrDefault(i => i.GetProperty("codTipo").GetString() == "V");

            if (!TryParseValor(compraItem, out var compra) || !TryParseValor(ventaItem, out var venta))
            {
                continue;
            }

            resultado.Add(new TipoCambioConsultaDto
            {
                Fecha = fecha,
                PrecioCompra = compra,
                PrecioVenta = venta
            });
        }

        return resultado;
    }

    private static bool TryParseValor(JsonElement? item, out decimal valor)
    {
        valor = 0;

        if (item is null ||
            !item.Value.TryGetProperty("valTipo", out var prop) ||
            !TryParseDecimal(prop.GetString() ?? string.Empty, out var parsed))
        {
            return false;
        }

        valor = parsed;
        return true;
    }

    private static bool TryParseDecimal(string valor, out decimal resultado)
    {
        valor = valor.Replace(',', '.');
        return decimal.TryParse(valor, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out resultado);
    }
}
