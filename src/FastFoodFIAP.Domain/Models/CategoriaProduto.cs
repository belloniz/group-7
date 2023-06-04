using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models
{
    public class CategoriaProduto: Entity, IAggregateRoot
    {
        public string Nome { get; private set; } = "";


        private CategoriaProduto() { 
        }

        public CategoriaProduto(string nome){
            Nome=nome;            
        }        
    }
}