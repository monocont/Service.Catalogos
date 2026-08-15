using MediatR;
using Service.Catalogos.Application.DTOs.Ubigeo;

namespace Service.Catalogos.Application.Queries.Ubigeo.ObtenerDepartamentos;

public class ObtenerDepartamentosQuery : IRequest<List<DepartamentoDTO>> { }