using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models
{
    public class Funcionario: Entity, IAggregateRoot
    {
        
        public int FuncionarioId { get; private set; }    
        public string? Nome { get; private set; }  = "";
        public string? Matricula { get; private set; }  = "";
        public int OcupacaoId {get; private set;}

        public virtual Ocupacao? OcupacaoNavegation { get; private set; }
        
        public Funcionario(int id, string nome, string matricula, int ocupacaoId) 
        {
            Id = id;
            Nome = nome;            
            Matricula = matricula;
            OcupacaoId = ocupacaoId;
        }
    }
}
