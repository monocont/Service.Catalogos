using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.Moneda.ObtenerMonedas;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/monedas")]
public class MonedaController : ControllerBase
{
    private readonly IMediator _mediator;

    public MonedaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerMonedas(CancellationToken cancellationToken)
    {
        var query = new ObtenerMonedasQuery();
        var resultado = await _mediator.Send(query, cancellationToken);
        
        return Ok(resultado);
    }
}