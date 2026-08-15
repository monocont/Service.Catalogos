using MediatR;
using Service.Catalogos.Application.DTOs.DetraccionServicio;

namespace Service.Catalogos.Application.Queries.DetraccionServicio.ObtenerDetraccionesServicio;

public class ObtenerDetraccionesServicioQuery : IRequest<List<DetraccionServicioDTO>> { }
