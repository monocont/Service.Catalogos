using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.TipoCp.ObtenerTiposCp;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/tipo-cp")]
public class TipoCpController : ControllerBase
{
    private readonly IMediator _mediator;

    public TipoCpController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTiposCp(CancellationToken cancellationToken)
    {
        var query = new ObtenerTiposCpQuery();
        var resultado = await _mediator.Send(query, cancellationToken);

        return Ok(resultado);
    }
}
