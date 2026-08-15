using MediatR;
using Service.Catalogos.Application.DTOs.TipoDocumentoModif;

namespace Service.Catalogos.Application.Queries.TipoDocumentoModif.ObtenerTiposDocumentoModif;

public class ObtenerTiposDocumentoModifQuery : IRequest<List<TipoDocumentoModifDTO>> { }
