using MediatR;
using Service.Catalogos.Application.DTOs.TipoOperacion;

namespace Service.Catalogos.Application.Queries.TipoOperacion.ObtenerTiposOperacion;

public class ObtenerTiposOperacionQuery : IRequest<List<TipoOperacionDTO>> { }
