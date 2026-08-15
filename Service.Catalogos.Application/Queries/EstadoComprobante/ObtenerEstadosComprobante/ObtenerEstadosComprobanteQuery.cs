using MediatR;
using Service.Catalogos.Application.DTOs.EstadoComprobante;

namespace Service.Catalogos.Application.Queries.EstadoComprobante.ObtenerEstadosComprobante;

public class ObtenerEstadosComprobanteQuery : IRequest<List<EstadoComprobanteDTO>> { }
