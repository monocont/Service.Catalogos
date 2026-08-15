using MediatR;

namespace Service.Catalogos.Application.Commands.TipoCambio.LlenarDiario;

public class LlenarTipoCambioDiarioCommand : IRequest<bool>
{
    public string Usuario { get; }

    public LlenarTipoCambioDiarioCommand(string usuario)
    {
        Usuario = usuario;
    }
}
