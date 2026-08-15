using MediatR;
using Service.Catalogos.Application.DTOs.Ubigeo;

namespace Service.Catalogos.Application.Queries.Ubigeo.ObtenerProvincias;

public class ObtenerProvinciasQuery : IRequest<List<ProvinciaDTO>>
{
    public string CodigoDepartamento { get; }

    public ObtenerProvinciasQuery(string codigoDepartamento)
    {
        CodigoDepartamento = codigoDepartamento;
    }
}