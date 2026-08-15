using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.EstadoComprobante.ObtenerEstadosComprobante;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/estado-comprobante")]
public class EstadoComprobanteController : ControllerBase
{
    private readonly IMediator _mediator;

    public EstadoComprobanteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerEstadosComprobante(CancellationToken cancellationToken)
    {
        var query = new ObtenerEstadosComprobanteQuery();
        var resultado = await _mediator.Send(query, cancellationToken);

        return Ok(resultado);
    }
}
