using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.TipoOperacion.ObtenerTiposOperacion;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/tipo-operacion")]
public class TipoOperacionController : ControllerBase
{
    private readonly IMediator _mediator;

    public TipoOperacionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTiposOperacion(CancellationToken cancellationToken)
    {
        var query = new ObtenerTiposOperacionQuery();
        var resultado = await _mediator.Send(query, cancellationToken);

        return Ok(resultado);
    }
}
