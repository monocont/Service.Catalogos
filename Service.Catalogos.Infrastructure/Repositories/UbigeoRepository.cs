using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Service.Catalogos.Application.DTOs.Ubigeo;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class UbigeoRepository : IUbigeoRepository
{
    private readonly Database.CatalogosDbContext _context;
    private readonly IMemoryCache _cache;
    private static readonly TimeSpan CacheDuration = TimeSpan.FromHours(12);
    private static readonly string CacheKeyDepartamentos = "Ubigeo_Departamentos";

    public UbigeoRepository(Database.CatalogosDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<List<Ubigeo>> ObtenerDepartamentosAsync(CancellationToken cancellationToken)
    {
        return (await _cache.GetOrCreateAsync(CacheKeyDepartamentos, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = CacheDuration;
            return await _context.Set<Ubigeo>()
                .Where(u => u.CodigoProvincia == null)
                .AsNoTracking()
                .OrderBy(u => u.CodigoUbigeo)
                .ToListAsync(cancellationToken);
        }))!;
    }

    public async Task<List<Ubigeo>> ObtenerProvinciasAsync(string codigoDepartamento, CancellationToken cancellationToken)
    {
        return await _context.Set<Ubigeo>()
            .Where(u => u.CodigoDepartamento == codigoDepartamento
                     && u.CodigoProvincia != null
                     && u.CodigoDistrito == null)
            .AsNoTracking()
            .OrderBy(u => u.CodigoUbigeo)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Ubigeo>> ObtenerDistritosAsync(string codigoProvincia, CancellationToken cancellationToken)
    {
        return await _context.Set<Ubigeo>()
            .Where(u => u.CodigoProvincia == codigoProvincia
                     && u.CodigoDistrito != null)
            .AsNoTracking()
            .OrderBy(u => u.CodigoUbigeo)
            .ToListAsync(cancellationToken);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}