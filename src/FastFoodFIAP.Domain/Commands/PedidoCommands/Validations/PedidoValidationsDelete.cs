namespace FastFoodFIAP.Domain.Commands.PedidoCommands.Validations
{
    public class PedidoValidationsDelete: PedidoValidations<PedidoDeleteCommand>
    {
        public PedidoValidationsDelete(){            
            ValidaId();
        }
    }
}

