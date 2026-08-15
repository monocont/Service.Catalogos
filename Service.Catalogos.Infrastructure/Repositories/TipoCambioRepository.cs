using Microsoft.EntityFrameworkCore;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class TipoCambioRepository : ITipoCambioRepository
{
    private readonly Database.CatalogosDbContext _context;

    public TipoCambioRepository(Database.CatalogosDbContext context) => _context = context;

    public async Task<List<TipoCambio>> ObtenerPorMonedaOrigenAsync(
        string codigoMonedaOrigen,
        DateTime? fechaDesde,
        DateTime? fechaHasta,
        CancellationToken cancellationToken)
    {
        var query = _context.Set<TipoCambio>()
            .Where(t => t.CodigoMonedaOrigen == codigoMonedaOrigen);

        if (fechaDesde.HasValue)
        {
            query = query.Where(t => t.Fecha >= fechaDesde.Value);
        }

        if (fechaHasta.HasValue)
        {
            query = query.Where(t => t.Fecha <= fechaHasta.Value);
        }

        return await query
            .AsNoTracking()
            .OrderByDescending(t => t.Fecha)
            .ToListAsync(cancellationToken);
    }

    public async Task<TipoCambio?> ObtenerPorMonedaOrigenYFechaAsync(
        string codigoMonedaOrigen,
        DateTime fecha,
        CancellationToken cancellationToken)
    {
        return await _context.Set<TipoCambio>()
            .FirstOrDefaultAsync(t =>
                t.CodigoMonedaOrigen == codigoMonedaOrigen &&
                t.Fecha == fecha, cancellationToken);
    }

    public async Task<TipoCambio?> ObtenerPorClaveAsync(
        string codigoMonedaOrigen,
        string codigoMonedaDestino,
        DateTime fecha,
        CancellationToken cancellationToken)
    {
        return await _context.Set<TipoCambio>()
            .FirstOrDefaultAsync(t =>
                t.CodigoMonedaOrigen == codigoMonedaOrigen &&
                t.CodigoMonedaDestino == codigoMonedaDestino &&
                t.Fecha == fecha, cancellationToken);
    }

    public async Task<List<DateTime>> ObtenerFechasConDatosAsync(
        string codigoMonedaOrigen,
        string codigoMonedaDestino,
        DateTime fechaDesde,
        DateTime fechaHasta,
        CancellationToken cancellationToken)
    {
        return await _context.Set<TipoCambio>()
            .Where(t =>
                t.CodigoMonedaOrigen == codigoMonedaOrigen &&
                t.CodigoMonedaDestino == codigoMonedaDestino &&
                t.Fecha >= fechaDesde &&
                t.Fecha <= fechaHasta)
            .Select(t => t.Fecha)
            .Distinct()
            .ToListAsync(cancellationToken);
    }

    public async Task InsertarAsync(TipoCambio entity, CancellationToken cancellationToken)
    {
        await _context.Set<TipoCambio>().AddAsync(entity, cancellationToken);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}