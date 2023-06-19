using FastFoodFIAP.Domain.Commands.PedidoCommands.Validations;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.PedidoCommands{

    public class PedidoUpdateCommand : PedidoCommand
    {
        protected PedidoUpdateCommand(){}

        public PedidoUpdateCommand(int id, int clienteId){
            Id = id;
            ClienteId = clienteId;
        }

        public void SetId(int id){
            Id=id;
        }

        public override bool IsValid()
        {
            ValidationResult = new PedidoValidationsUpdate().Validate(this);
            return ValidationResult.IsValid;
        }   
    }
}
