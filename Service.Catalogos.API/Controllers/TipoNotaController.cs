using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.Queries.TipoNota.ObtenerTiposNota;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/tipo-nota")]
public class TipoNotaController : ControllerBase
{
    private readonly IMediator _mediator;

    public TipoNotaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTiposNota(CancellationToken cancellationToken)
    {
        var query = new ObtenerTiposNotaQuery();
        var resultado = await _mediator.Send(query, cancellationToken);

        return Ok(resultado);
    }
}
