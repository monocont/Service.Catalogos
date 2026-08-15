namespace Service.Catalogos.Domain.Entities;

public class Ubigeo
{
    public string CodigoUbigeo { get; private set; } = string.Empty;
    public string CodigoDepartamento { get; private set; } = string.Empty;
    public string Departamento { get; private set; } = string.Empty;
    public string? CodigoProvincia { get; private set; }
    public string? Provincia { get; private set; }
    public string? CodigoDistrito { get; private set; }
    public string? Distrito { get; private set; }

    private Ubigeo() { }

    public static Ubigeo Crear(
        string codigoUbigeo,
        string codigoDepartamento,
        string departamento,
        string? codigoProvincia,
        string? provincia,
        string? codigoDistrito,
        string? distrito)
    {
        return new Ubigeo
        {
            CodigoUbigeo = codigoUbigeo,
            CodigoDepartamento = codigoDepartamento,
            Departamento = departamento,
            CodigoProvincia = codigoProvincia,
            Provincia = provincia,
            CodigoDistrito = codigoDistrito,
            Distrito = distrito
        };
    }
}