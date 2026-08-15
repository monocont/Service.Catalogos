using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Service.Catalogos.Application.Common.Exceptions;
using Service.Catalogos.Application.DTOs.TipoCambio;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.TipoCambio.ObtenerTipoCambio;

public class ObtenerTipoCambioQueryHandler : IRequestHandler<ObtenerTipoCambioQuery, ObtenerTipoCambioDTO?>
{
    private static readonly TimeZoneInfo ZonaPeru = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");

    private readonly ITipoCambioRepository _repositorio;
    private readonly IMemoryCache _cache;

    public ObtenerTipoCambioQueryHandler(ITipoCambioRepository repositorio, IMemoryCache cache)
    {
        _repositorio = repositorio;
        _cache = cache;
    }

    public async Task<ObtenerTipoCambioDTO?> Handle(ObtenerTipoCambioQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"{request.Fecha:dd/MM/yyyy}-{request.CodigoMonedaOrigen}";

        if (_cache.TryGetValue(cacheKey, out ObtenerTipoCambioDTO? cacheado))
        {
            return cacheado;
        }

        var tipoCambio = await _repositorio.ObtenerPorMonedaOrigenYFechaAsync(
            request.CodigoMonedaOrigen,
            request.Fecha,
            cancellationToken);

        if (tipoCambio is null)
        {
            throw new NotFoundException($"No se encontró el tipo de cambio para la moneda {request.CodigoMonedaOrigen} en la fecha {request.Fecha:dd/MM/yyyy}.");
        }

        var dto = new ObtenerTipoCambioDTO
        {
            CodigoMonedaOrigen = tipoCambio.CodigoMonedaOrigen,
            CodigoMonedaDestino = tipoCambio.CodigoMonedaDestino,
            Fecha = tipoCambio.Fecha,
            PrecioCompra = tipoCambio.PrecioCompra,
            PrecioVenta = tipoCambio.PrecioVenta
        };

        var hoyPeru = TimeZoneInfo.ConvertTime(DateTime.UtcNow, ZonaPeru).Date;

        if (request.Fecha.Date == hoyPeru)
        {
            _cache.Set(cacheKey, dto, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TiempoHastaFinDelDia()
            });
        }

        return dto;
    }

    private static TimeSpan TiempoHastaFinDelDia()
    {
        var ahoraPeru = TimeZoneInfo.ConvertTime(DateTime.UtcNow, ZonaPeru);
        var finDelDia = ahoraPeru.Date.AddDays(1);
        return finDelDia - ahoraPeru;
    }
}