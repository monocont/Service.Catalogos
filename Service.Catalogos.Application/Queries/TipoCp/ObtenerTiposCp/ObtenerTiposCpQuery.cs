using MediatR;
using Service.Catalogos.Application.DTOs.TipoCp;

namespace Service.Catalogos.Application.Queries.TipoCp.ObtenerTiposCp;

public class ObtenerTiposCpQuery : IRequest<List<TipoCpDTO>> { }
