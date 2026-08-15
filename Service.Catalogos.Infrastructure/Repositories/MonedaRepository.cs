using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class MonedaRepository : IMonedaRepository
{
    private readonly Database.CatalogosDbContext _context;
    private readonly IMemoryCache _cache;
    private static readonly TimeSpan CacheDuration = TimeSpan.FromHours(12);
    private static readonly string CacheKeyMoneda = "Moneda_List";

    public MonedaRepository(Database.CatalogosDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<List<Moneda>> ObtenerMonedasAsync(CancellationToken cancellationToken)
    {
        return (await _cache.GetOrCreateAsync(CacheKeyMoneda, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            return await _context.Set<Moneda>()
                .AsNoTracking()
                .OrderBy(m => m.CodigoIso)
                .ToListAsync(cancellationToken);
        }))!;
    }
}