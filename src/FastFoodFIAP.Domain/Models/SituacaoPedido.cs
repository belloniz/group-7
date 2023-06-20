using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models
{
    public partial class SituacaoPedido: Entity, IAggregateRoot
    {
        public string Nome { get; private set; } = "";

        private SituacaoPedido() { 
        }

        public SituacaoPedido(int id, string nome){
            Id = id;
            Nome=nome;         
        }        
    }
}