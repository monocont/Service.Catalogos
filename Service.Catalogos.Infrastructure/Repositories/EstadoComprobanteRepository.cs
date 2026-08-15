using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class EstadoComprobanteRepository : IEstadoComprobanteRepository
{
    private readonly Database.CatalogosDbContext _context;
    private readonly IMemoryCache _cache;
    private static readonly TimeSpan CacheDuration = TimeSpan.FromHours(12);
    private static readonly string CacheKey = "EstadoComprobante_List";

    public EstadoComprobanteRepository(Database.CatalogosDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<List<EstadoComprobante>> ObtenerEstadosComprobanteAsync(CancellationToken cancellationToken)
    {
        return (await _cache.GetOrCreateAsync(CacheKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            return await _context.Set<EstadoComprobante>()
                .AsNoTracking()
                .OrderBy(e => e.Codigo)
                .ToListAsync(cancellationToken);
        }))!;
    }
}
