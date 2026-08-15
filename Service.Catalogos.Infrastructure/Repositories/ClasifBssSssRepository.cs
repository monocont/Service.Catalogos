using Microsoft.EntityFrameworkCore;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class ClasifBssSssRepository : IClasifBssSssRepository
{
    private readonly Database.CatalogosDbContext _context;

    public ClasifBssSssRepository(Database.CatalogosDbContext context)
    {
        _context = context;
    }

    public async Task<List<ClasifBssSss>> ObtenerClasificacionesBssSssAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<ClasifBssSss>()
            .AsNoTracking()
            .OrderBy(c => c.Codigo)
            .ToListAsync(cancellationToken);
    }
}
