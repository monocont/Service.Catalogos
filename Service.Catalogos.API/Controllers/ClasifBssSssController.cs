using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.ClasifBssSss.ObtenerClasifBssSss;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/clasif-bss-sss")]
public class ClasifBssSssController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClasifBssSssController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerClasifBssSss(CancellationToken cancellationToken)
    {
        var query = new ObtenerClasifBssSssQuery();
        var resultado = await _mediator.Send(query, cancellationToken);

        return Ok(resultado);
    }
}
