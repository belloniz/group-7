
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class CategoriaProdutoRepository : ICategoriaProdutoRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<CategoriaProduto> DbSet;

        public CategoriaProdutoRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<CategoriaProduto>();            
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Add(CategoriaProduto categoria)
        {
            DbSet.Add(categoria);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public IEnumerable<CategoriaProduto> GetAll()
        {
            return DbSet.AsNoTracking().OrderBy(on => on.Nome);                       
        }

        public CategoriaProduto? GetById(int id)
        {
             return DbSet.Find(id);
        }

        public void Remove(CategoriaProduto categoria)
        {
            DbSet.Remove(categoria);
        }

        public void Update(CategoriaProduto categoria)
        {
            DbSet.Update(categoria);
        }
    }
}