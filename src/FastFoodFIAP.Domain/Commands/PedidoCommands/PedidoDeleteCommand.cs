using FastFoodFIAP.Domain.Commands.PedidoCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.PedidoCommands{

    public class PedidoDeleteCommand: PedidoCommand
    {
        protected PedidoDeleteCommand(){}

        public PedidoDeleteCommand(Guid id){
            Id = id;
        }

        public override bool IsValid()
        {
            CommandResult.ValidationResult = new PedidoValidationsDelete().Validate(this);
            return CommandResult.ValidationResult.IsValid;
        }
    }
}
