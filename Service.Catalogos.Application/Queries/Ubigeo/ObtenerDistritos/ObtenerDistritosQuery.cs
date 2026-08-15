using MediatR;
using Service.Catalogos.Application.DTOs.Ubigeo;

namespace Service.Catalogos.Application.Queries.Ubigeo.ObtenerDistritos;

public class ObtenerDistritosQuery : IRequest<List<DistritoDTO>>
{
    public string CodigoProvincia { get; }

    public ObtenerDistritosQuery(string codigoProvincia)
    {
        CodigoProvincia = codigoProvincia;
    }
}