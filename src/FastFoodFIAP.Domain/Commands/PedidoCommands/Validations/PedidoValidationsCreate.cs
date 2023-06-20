namespace FastFoodFIAP.Domain.Commands.PedidoCommands.Validations
{
    public class PedidoValidationsCreate: PedidoValidations<PedidoCreateCommand>
    {
        public PedidoValidationsCreate(){            
            ValidaCliente();
        }
    }
}
