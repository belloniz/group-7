using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models
{
    public class Funcionario: Entity, IAggregateRoot
    {   
        public string Nome { get; private set; }  = "";
        public string Matricula { get; private set; }  = "";
        public Guid OcupacaoId { get; private set;}

        public virtual Ocupacao? OcupacaoNavegation { get; private set; }
        
        public Funcionario(Guid id, string nome, string matricula, Guid ocupacaoId) 
        {
            Id = id;
            Nome = nome;            
            Matricula = matricula;
            OcupacaoId = ocupacaoId;
        }
    }
}
