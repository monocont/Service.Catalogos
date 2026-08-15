using MediatR;
using Service.Catalogos.Application.DTOs.TipoNota;

namespace Service.Catalogos.Application.Queries.TipoNota.ObtenerTiposNota;

public class ObtenerTiposNotaQuery : IRequest<List<TipoNotaDTO>> { }
