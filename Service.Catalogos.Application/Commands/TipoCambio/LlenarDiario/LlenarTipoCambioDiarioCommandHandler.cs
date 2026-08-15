using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Service.Catalogos.Application.Interfaces;
using TipoCambioEntity = Service.Catalogos.Domain.Entities.TipoCambio;

namespace Service.Catalogos.Application.Commands.TipoCambio.LlenarDiario;

public class LlenarTipoCambioDiarioCommandHandler : IRequestHandler<LlenarTipoCambioDiarioCommand, bool>
{
    private const string MonedaOrigen = "USD";
    private const string MonedaDestino = "PEN";
    private const string UsuarioCore = "CORE";

    private readonly ISunatTipoCambioService _sunatTipoCambioService;
    private readonly ITipoCambioRepository _repositorio;
    private readonly IMemoryCache _cache;

    public LlenarTipoCambioDiarioCommandHandler(
        ISunatTipoCambioService sunatTipoCambioService,
        ITipoCambioRepository repositorio,
        IMemoryCache cache)
    {
        _sunatTipoCambioService = sunatTipoCambioService;
        _repositorio = repositorio;
        _cache = cache;
    }

    public async Task<bool> Handle(LlenarTipoCambioDiarioCommand request, CancellationToken cancellationToken)
    {
        var tipoCambioSunat = await _sunatTipoCambioService.ObtenerDelDiaAsync(cancellationToken);

        if (tipoCambioSunat is null)
        {
            return false;
        }

        var existente = await _repositorio.ObtenerPorClaveAsync(
            MonedaOrigen,
            MonedaDestino,
            tipoCambioSunat.Fecha,
            cancellationToken);

        if (existente is not null)
        {
            if (request.Usuario == UsuarioCore)
            {
                existente.Actualizar(tipoCambioSunat.PrecioCompra, tipoCambioSunat.PrecioVenta, UsuarioCore);
                await _repositorio.CommitAsync();
            }
        }
        else
        {
            var nuevo = TipoCambioEntity.Crear(
                MonedaOrigen,
                MonedaDestino,
                tipoCambioSunat.Fecha,
                tipoCambioSunat.PrecioCompra,
                tipoCambioSunat.PrecioVenta,
                request.Usuario);

            await _repositorio.InsertarAsync(nuevo, cancellationToken);
            await _repositorio.CommitAsync();
        }

        if (request.Usuario == UsuarioCore)
        {
            InvalidarCache(tipoCambioSunat.Fecha);
        }

        return true;
    }

    private void InvalidarCache(DateTime fecha)
    {
        var cacheKey = $"{fecha:dd/MM/yyyy}-{MonedaOrigen}";
        _cache.Remove(cacheKey);
    }
}
