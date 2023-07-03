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
            ValidationResult = new PedidoValidationsDelete().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
