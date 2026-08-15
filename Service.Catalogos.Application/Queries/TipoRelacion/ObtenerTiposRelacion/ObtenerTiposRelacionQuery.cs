using MediatR;
using Service.Catalogos.Application.DTOs.TipoRelacion;

namespace Service.Catalogos.Application.Queries.TipoRelacion.ObtenerTiposRelacion;

public class ObtenerTiposRelacionQuery : IRequest<List<TipoRelacionDTO>> { }
