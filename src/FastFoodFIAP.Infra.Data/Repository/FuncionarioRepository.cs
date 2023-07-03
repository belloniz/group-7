using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class FuncionarioRepository: IFuncionarioRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<Funcionario> DbSet;

        public FuncionarioRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Funcionario>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<Funcionario>> GetAll()
        {
            return await DbSet.AsNoTracking().OrderBy(on => on.Nome).ToListAsync();
        }
        
        public async Task<Funcionario?> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(Funcionario funcionario)
        {
            DbSet.Add(funcionario);        
        }

        public void Remove(Funcionario funcionario)
        {
            DbSet.Remove(funcionario);
        }

        public void Update(Funcionario funcionario)
        {
            DbSet.Update(funcionario);          
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
