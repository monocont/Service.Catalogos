using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.UnidadMedida.ObtenerUnidadesMedida;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/unidad-medida")]
public class UnidadMedidaController : ControllerBase
{
    private readonly IMediator _mediator;

    public UnidadMedidaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerUnidadesMedida(CancellationToken cancellationToken)
    {
        var query = new ObtenerUnidadesMedidaQuery();
        var resultado = await _mediator.Send(query, cancellationToken);

        return Ok(resultado);
    }
}
