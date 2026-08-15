using FluentValidation;

namespace Service.Catalogos.Application.Queries.Ubigeo.ObtenerProvincias;

public class ObtenerProvinciasValidator : AbstractValidator<ObtenerProvinciasQuery>
{
    public ObtenerProvinciasValidator()
    {
        RuleFor(x => x.CodigoDepartamento)
            .NotEmpty()
            .WithMessage("El código de departamento es obligatorio.")
            .Length(2)
            .WithMessage("El código de departamento debe tener exactamente 2 caracteres.");
    }
}