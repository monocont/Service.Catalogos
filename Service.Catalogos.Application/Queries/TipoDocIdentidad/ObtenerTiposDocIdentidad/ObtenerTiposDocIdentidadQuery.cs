using MediatR;
using Service.Catalogos.Application.DTOs.TipoDocIdentidad;

namespace Service.Catalogos.Application.Queries.TipoDocIdentidad.ObtenerTiposDocIdentidad;

public class ObtenerTiposDocIdentidadQuery : IRequest<List<TipoDocIdentidadDTO>> { }
