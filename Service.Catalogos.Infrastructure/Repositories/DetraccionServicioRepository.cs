using Microsoft.EntityFrameworkCore;
using Service.Catalogos.Application.Interfaces;
using Service.Catalogos.Domain.Entities;

namespace Service.Catalogos.Infrastructure.Repositories;

public class DetraccionServicioRepository : IDetraccionServicioRepository
{
    private readonly Database.CatalogosDbContext _context;

    public DetraccionServicioRepository(Database.CatalogosDbContext context)
    {
        _context = context;
    }

    public async Task<List<DetraccionServicio>> ObtenerDetraccionesServicioAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<DetraccionServicio>()
            .AsNoTracking()
            .OrderBy(d => d.Codigo)
            .ToListAsync(cancellationToken);
    }
}
