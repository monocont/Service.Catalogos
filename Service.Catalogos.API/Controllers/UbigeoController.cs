using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Catalogos.Application.DTOs.Ubigeo;
using Service.Catalogos.Application.Queries.Ubigeo.ObtenerDepartamentos;
using Service.Catalogos.Application.Queries.Ubigeo.ObtenerDistritos;
using Service.Catalogos.Application.Queries.Ubigeo.ObtenerProvincias;

namespace Service.Catalogos.API.Controllers;

[ApiController]
[Route("api/v1/ubigeo")]
public class UbigeoController : ControllerBase
{
    private readonly IMediator _mediator;

    public UbigeoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("departamentos")]
    public async Task<IActionResult> ObtenerDepartamentos(CancellationToken cancellationToken)
    {
        var query = new ObtenerDepartamentosQuery();
        var resultado = await _mediator.Send(query, cancellationToken);
        
        return Ok(resultado);
    }

    [HttpGet("provincias")]
    public async Task<IActionResult> ObtenerProvincias(
        [FromQuery] string? codigoDepartamento,
        CancellationToken cancellationToken)
    {
        var query = new ObtenerProvinciasQuery(codigoDepartamento!);
        var resultado = await _mediator.Send(query, cancellationToken);
        
        return Ok(resultado);
    }

    [HttpGet("distritos")]
    public async Task<IActionResult> ObtenerDistritos(
        [FromQuery] string? codigoProvincia,
        CancellationToken cancellationToken)
    {
        var query = new ObtenerDistritosQuery(codigoProvincia!);
        var resultado = await _mediator.Send(query, cancellationToken);
        
        return Ok(resultado);
    }
}