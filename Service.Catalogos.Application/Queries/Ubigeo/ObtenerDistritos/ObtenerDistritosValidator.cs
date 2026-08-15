using FluentValidation;

namespace Service.Catalogos.Application.Queries.Ubigeo.ObtenerDistritos;

public class ObtenerDistritosValidator : AbstractValidator<ObtenerDistritosQuery>
{
    public ObtenerDistritosValidator()
    {
        RuleFor(x => x.CodigoProvincia)
            .NotEmpty()
            .WithMessage("El código de provincia es obligatorio.")
            .Length(4)
            .WithMessage("El código de provincia debe tener exactamente 4 caracteres.");
    }
}