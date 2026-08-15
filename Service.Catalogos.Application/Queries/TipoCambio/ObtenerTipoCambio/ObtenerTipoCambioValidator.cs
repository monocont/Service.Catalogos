using FluentValidation;

namespace Service.Catalogos.Application.Queries.TipoCambio.ObtenerTipoCambio;

public class ObtenerTipoCambioValidator : AbstractValidator<ObtenerTipoCambioQuery>
{
    public ObtenerTipoCambioValidator()
    {
        RuleFor(x => x.CodigoMonedaOrigen)
            .NotEmpty()
            .WithMessage("El código de moneda origen es obligatorio.")
            .Length(3)
            .WithMessage("El código de moneda origen debe tener exactamente 3 caracteres.");

        RuleFor(x => x.Fecha)
            .NotEmpty()
            .WithMessage("La fecha es obligatoria.");
    }
}