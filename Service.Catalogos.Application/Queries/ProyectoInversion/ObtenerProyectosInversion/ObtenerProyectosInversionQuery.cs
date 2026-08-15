using MediatR;
using Service.Catalogos.Application.DTOs.ProyectoInversion;

namespace Service.Catalogos.Application.Queries.ProyectoInversion.ObtenerProyectosInversion;

public class ObtenerProyectosInversionQuery : IRequest<List<ProyectoInversionDTO>> { }
