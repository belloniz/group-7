using FastFoodFIAP.Domain.Models.Pagamento;
using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.PagamentoCommands{

    public class PagamentoUpdateCommand : PagamentoCommands
    {
        protected PagamentoUpdateCommand(){}

        public PagamentoUpdateCommand(Guid id, int situacaoId){
            Id = id;
            SituacaoId = situacaoId;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
