using Microsoft.EntityFrameworkCore;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class TipoNotaRepository : ITipoNotaRepository
{
    private readonly Database.CatalogosDbContext _context;

    public TipoNotaRepository(Database.CatalogosDbContext context)
    {
        _context = context;
    }

    public async Task<List<TipoNota>> ObtenerTiposNotaAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<TipoNota>()
            .AsNoTracking()
            .OrderBy(t => t.Codigo)
            .ToListAsync(cancellationToken);
    }
}
