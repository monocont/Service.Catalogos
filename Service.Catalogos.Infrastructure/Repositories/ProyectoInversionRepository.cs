using Microsoft.EntityFrameworkCore;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class ProyectoInversionRepository : IProyectoInversionRepository
{
    private readonly Database.CatalogosDbContext _context;

    public ProyectoInversionRepository(Database.CatalogosDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProyectoInversion>> ObtenerProyectosInversionAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<ProyectoInversion>()
            .AsNoTracking()
            .OrderBy(p => p.Codigo)
            .ToListAsync(cancellationToken);
    }
}
