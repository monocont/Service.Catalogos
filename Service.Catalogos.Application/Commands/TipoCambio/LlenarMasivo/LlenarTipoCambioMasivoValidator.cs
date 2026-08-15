using FluentValidation;

namespace Service.Catalogos.Application.Commands.TipoCambio.LlenarMasivo;

public class LlenarTipoCambioMasivoValidator : AbstractValidator<LlenarTipoCambioMasivoCommand>
{
    private static readonly TimeZoneInfo ZonaPeru = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");

    public LlenarTipoCambioMasivoValidator()
    {
        RuleFor(x => x.Anio)
            .GreaterThanOrEqualTo(2000)
            .WithMessage("El año debe ser mayor o igual a 2000.");

        RuleFor(x => x.Mes)
            .InclusiveBetween(1, 12)
            .WithMessage("El mes debe estar entre 1 y 12.");

        RuleFor(x => x)
            .Must(SerMesNoFuturo)
            .WithMessage("El periodo seleccionado aún no ha llegado. Solo se pueden obtener datos de meses ya transcurridos o del mes actual.");

        RuleFor(x => x.MonedaOrigen)
            .NotEmpty()
            .WithMessage("La moneda origen es obligatoria.")
            .Length(3)
            .WithMessage("La moneda origen debe tener exactamente 3 caracteres.");

        RuleFor(x => x.MonedaDestino)
            .NotEmpty()
            .WithMessage("La moneda destino es obligatoria.")
            .Length(3)
            .WithMessage("La moneda destino debe tener exactamente 3 caracteres.");

        RuleFor(x => x.Usuario)
            .NotEmpty()
            .WithMessage("El usuario es obligatorio.");
    }

    private static bool SerMesNoFuturo(LlenarTipoCambioMasivoCommand request)
    {
        var hoy = TimeZoneInfo.ConvertTime(DateTime.UtcNow, ZonaPeru);

        if (request.Anio < hoy.Year)
        {
            return true;
        }

        if (request.Anio > hoy.Year)
        {
            return false;
        }

        return request.Mes <= hoy.Month;
    }
}
