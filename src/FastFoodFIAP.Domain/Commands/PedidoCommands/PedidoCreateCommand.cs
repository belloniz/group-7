using FastFoodFIAP.Domain.Commands.PedidoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.PedidoCommands{

    public class PedidoCreateCommand : PedidoCommand
    {
        protected PedidoCreateCommand(){}

        public PedidoCreateCommand(int clienteId){            
            ClienteId = clienteId;
        }

        public override bool IsValid()
        {
            ValidationResult = new PedidoValidationsCreate().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}