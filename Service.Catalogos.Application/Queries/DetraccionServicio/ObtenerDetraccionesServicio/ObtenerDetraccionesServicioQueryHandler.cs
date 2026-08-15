using MediatR;
using Service.Catalogos.Application.DTOs.DetraccionServicio;
using Service.Catalogos.Application.Interfaces;

namespace Service.Catalogos.Application.Queries.DetraccionServicio.ObtenerDetraccionesServicio;

public class ObtenerDetraccionesServicioQueryHandler : IRequestHandler<ObtenerDetraccionesServicioQuery, List<DetraccionServicioDTO>>
{
    private readonly IDetraccionServicioRepository _repositorio;

    public ObtenerDetraccionesServicioQueryHandler(IDetraccionServicioRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<DetraccionServicioDTO>> Handle(ObtenerDetraccionesServicioQuery request, CancellationToken cancellationToken)
    {
        var detracciones = await _repositorio.ObtenerDetraccionesServicioAsync(cancellationToken);

        return detracciones.Select(d => new DetraccionServicioDTO
        {
            Codigo = d.Codigo,
            Descripcion = d.Descripcion,
            Porcentaje = d.Porcentaje,
            BienServicio = d.BienServicio,
            FechaVigencia = d.FechaVigencia,
            Activo = d.Activo
        }).ToList();
    }
}
