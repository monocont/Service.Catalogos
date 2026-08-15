using Microsoft.EntityFrameworkCore;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class UnidadMedidaRepository : IUnidadMedidaRepository
{
    private readonly Database.CatalogosDbContext _context;

    public UnidadMedidaRepository(Database.CatalogosDbContext context)
    {
        _context = context;
    }

    public async Task<List<UnidadMedida>> ObtenerUnidadesMedidaAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<UnidadMedida>()
            .AsNoTracking()
            .OrderBy(u => u.Codigo)
            .ToListAsync(cancellationToken);
    }
}
