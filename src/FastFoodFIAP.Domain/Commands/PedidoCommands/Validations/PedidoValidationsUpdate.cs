namespace FastFoodFIAP.Domain.Commands.PedidoCommands.Validations
{
    public class PedidoValidationsUpdate : PedidoValidations<PedidoUpdateCommand>
    {
        public PedidoValidationsUpdate(){        
            ValidaId();    
            ValidaCliente();
        }
    }
}
