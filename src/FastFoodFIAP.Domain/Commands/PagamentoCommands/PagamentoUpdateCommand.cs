using FastFoodFIAP.Domain.Models.Pagamento;
using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.PagamentoCommands{

    public class PagamentoUpdateCommand : PagamentoCommands
    {
        protected PagamentoUpdateCommand(){}

        public PagamentoUpdateCommand(Guid id){
            Id = id;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
