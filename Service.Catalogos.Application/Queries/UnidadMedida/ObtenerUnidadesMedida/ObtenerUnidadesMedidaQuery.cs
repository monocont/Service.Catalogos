using MediatR;
using Service.Catalogos.Application.DTOs.UnidadMedida;

namespace Service.Catalogos.Application.Queries.UnidadMedida.ObtenerUnidadesMedida;

public class ObtenerUnidadesMedidaQuery : IRequest<List<UnidadMedidaDTO>> { }
