using Microsoft.EntityFrameworkCore;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class TipoDocumentoModifRepository : ITipoDocumentoModifRepository
{
    private readonly Database.CatalogosDbContext _context;

    public TipoDocumentoModifRepository(Database.CatalogosDbContext context)
    {
        _context = context;
    }

    public async Task<List<TipoDocumentoModif>> ObtenerTiposDocumentoModifAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<TipoDocumentoModif>()
            .AsNoTracking()
            .OrderBy(t => t.Codigo)
            .ToListAsync(cancellationToken);
    }
}
