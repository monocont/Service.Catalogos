using MediatR;
using Service.Catalogos.Application.DTOs.Moneda;

namespace Service.Catalogos.Application.Queries.Moneda.ObtenerMonedas;

public class ObtenerMonedasQuery : IRequest<List<ObtenerMonedasDTO>> { }