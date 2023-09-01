using FastFoodFIAP.Domain.Commands.PedidoCommands.Validations;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.PedidoCommands{

    public class PedidoUpdateCommand : PedidoCommand
    {
        protected PedidoUpdateCommand(){}

        public PedidoUpdateCommand(Guid id, Guid? clienteId){
            Id = id;
            ClienteId = clienteId;
        }

        public void SetId(Guid id){
            Id=id;
        }

        public override bool IsValid()
        {
            CommandResult.ValidationResult = new PedidoValidationsUpdate().Validate(this);
            return CommandResult.ValidationResult.IsValid;
        }   
    }
}
