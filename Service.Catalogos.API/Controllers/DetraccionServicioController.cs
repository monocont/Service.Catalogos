using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.DetraccionServicio.ObtenerDetraccionesServicio;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/detraccion-servicio")]
public class DetraccionServicioController : ControllerBase
{
    private readonly IMediator _mediator;

    public DetraccionServicioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerDetraccionesServicio(CancellationToken cancellationToken)
    {
        var query = new ObtenerDetraccionesServicioQuery();
        var resultado = await _mediator.Send(query, cancellationToken);

        return Ok(resultado);
    }
}
