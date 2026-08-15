using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.ProyectoInversion.ObtenerProyectosInversion;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/proyecto-inversion")]
public class ProyectoInversionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProyectoInversionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerProyectosInversion(CancellationToken cancellationToken)
    {
        var query = new ObtenerProyectosInversionQuery();
        var resultado = await _mediator.Send(query, cancellationToken);

        return Ok(resultado);
    }
}
