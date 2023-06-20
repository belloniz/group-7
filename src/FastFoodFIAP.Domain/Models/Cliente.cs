using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models
{
    public partial class Cliente : Entity, IAggregateRoot
    {
        public string Nome { get; private set; } = "";
        public string Email { get; private set; } = "";
        public string Cpf { get; private set; } = "";

        public Cliente(int id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }
}

