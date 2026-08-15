using Microsoft.EntityFrameworkCore;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class TipoOperacionRepository : ITipoOperacionRepository
{
    private readonly Database.CatalogosDbContext _context;

    public TipoOperacionRepository(Database.CatalogosDbContext context)
    {
        _context = context;
    }

    public async Task<List<TipoOperacion>> ObtenerTiposOperacionAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<TipoOperacion>()
            .AsNoTracking()
            .OrderBy(t => t.Codigo)
            .ToListAsync(cancellationToken);
    }
}
