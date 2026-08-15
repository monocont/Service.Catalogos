using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.TipoRelacion.ObtenerTiposRelacion;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/tipo-relacion")]
public class TipoRelacionController : ControllerBase
{
    private readonly IMediator _mediator;

    public TipoRelacionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTiposRelacion(CancellationToken cancellationToken)
    {
        var query = new ObtenerTiposRelacionQuery();
        var resultado = await _mediator.Send(query, cancellationToken);

        return Ok(resultado);
    }
}
