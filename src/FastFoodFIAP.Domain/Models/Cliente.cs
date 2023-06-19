using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models
{
    public class Cliente: Entity, IAggregateRoot
    {
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public string? Cpf { get; private set; }


        private Cliente() { 
            Pedidos = new HashSet<Pedido>();
        }

        public Cliente(int id, string nome, string email){
            Id = id;
            Nome=nome;         
            Email = email;
            Pedidos = new HashSet<Pedido>();   
        }

        public Cliente(int id, string cpf){
            Id = id;
            Cpf = cpf;
            Pedidos = new HashSet<Pedido>();   
        }

        public virtual ICollection<Pedido> Pedidos { get; private set; } 
    }
}
