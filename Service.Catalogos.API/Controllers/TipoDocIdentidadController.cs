using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.TipoDocIdentidad.ObtenerTiposDocIdentidad;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/tipo-doc-identidad")]
public class TipoDocIdentidadController : ControllerBase
{
    private readonly IMediator _mediator;

    public TipoDocIdentidadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTiposDocIdentidad(CancellationToken cancellationToken)
    {
        var query = new ObtenerTiposDocIdentidadQuery();
        var resultado = await _mediator.Send(query, cancellationToken);

        return Ok(resultado);
    }
}
