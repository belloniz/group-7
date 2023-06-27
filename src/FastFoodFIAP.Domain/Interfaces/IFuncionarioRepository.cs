using FastFoodFIAP.Domain.Models;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IFuncionarioRepository: IRepository<Funcionario>
    {
        Task<Funcionario?> GetById(int id);
        Task<IEnumerable<Funcionario>> GetAll();
        void Add(Funcionario funcionario);
        void Update(Funcionario funcionario);
        void Remove(Funcionario funcionario);
    }
}
