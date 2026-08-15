using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class TipoDocIdentidadRepository : ITipoDocIdentidadRepository
{
    private readonly Database.CatalogosDbContext _context;
    private readonly IMemoryCache _cache;
    private static readonly TimeSpan CacheDuration = TimeSpan.FromHours(12);
    private static readonly string CacheKey = "TipoDocIdentidad_List";

    public TipoDocIdentidadRepository(Database.CatalogosDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<List<TipoDocIdentidad>> ObtenerTiposDocIdentidadAsync(CancellationToken cancellationToken)
    {
        return (await _cache.GetOrCreateAsync(CacheKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            return await _context.Set<TipoDocIdentidad>()
                .AsNoTracking()
                .OrderBy(t => t.Codigo)
                .ToListAsync(cancellationToken);
        }))!;
    }
}
