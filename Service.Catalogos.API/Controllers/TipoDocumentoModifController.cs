using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.TipoDocumentoModif.ObtenerTiposDocumentoModif;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/tipo-documento-modif")]
public class TipoDocumentoModifController : ControllerBase
{
    private readonly IMediator _mediator;

    public TipoDocumentoModifController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTiposDocumentoModif(CancellationToken cancellationToken)
    {
        var query = new ObtenerTiposDocumentoModifQuery();
        var resultado = await _mediator.Send(query, cancellationToken);

        return Ok(resultado);
    }
}
