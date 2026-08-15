using FluentValidation;

namespace Service.Catalogos.Application.Queries.TipoCambio.ObtenerPorMes;

public class ObtenerTipoCambioPorMesValidator : AbstractValidator<ObtenerTipoCambioPorMesQuery>
{
    private static readonly TimeZoneInfo ZonaPeru = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");

    public ObtenerTipoCambioPorMesValidator()
    {
        RuleFor(x => x.MonedaOrigen)
            .NotEmpty()
            .WithMessage("La moneda origen es obligatoria.")
            .Length(3)
            .WithMessage("La moneda origen debe tener exactamente 3 caracteres.");

        RuleFor(x => x.Anio)
            .GreaterThanOrEqualTo(2000)
            .WithMessage("El año debe ser mayor o igual a 2000.");

        RuleFor(x => x.Mes)
            .InclusiveBetween(1, 12)
            .WithMessage("El mes debe estar entre 1 y 12.");

        RuleFor(x => x)
            .Must(SerMesNoFuturo)
            .WithMessage("El periodo consultado aún no ha transcurrido. Solo puedes consultar datos de meses anteriores o del mes actual.");
    }

    private static bool SerMesNoFuturo(ObtenerTipoCambioPorMesQuery request)
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
