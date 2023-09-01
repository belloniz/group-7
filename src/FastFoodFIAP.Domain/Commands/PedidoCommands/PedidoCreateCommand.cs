using FastFoodFIAP.Domain.Commands.PedidoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.PedidoCommands{

    public class PedidoCreateCommand : PedidoCommand
    {
        protected PedidoCreateCommand(){}

        public PedidoCreateCommand(Guid? clienteId){            
            ClienteId = clienteId;
        }

        public override bool IsValid()
        {
            CommandResult.ValidationResult = new PedidoValidationsCreate().Validate(this);
            return CommandResult.ValidationResult.IsValid;
        }
    }
}