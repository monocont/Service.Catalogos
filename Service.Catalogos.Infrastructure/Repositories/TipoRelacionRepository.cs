using Microsoft.EntityFrameworkCore;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class TipoRelacionRepository : ITipoRelacionRepository
{
    private readonly Database.CatalogosDbContext _context;

    public TipoRelacionRepository(Database.CatalogosDbContext context)
    {
        _context = context;
    }

    public async Task<List<TipoRelacion>> ObtenerTiposRelacionAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<TipoRelacion>()
            .AsNoTracking()
            .OrderBy(t => t.Codigo)
            .ToListAsync(cancellationToken);
    }
}
