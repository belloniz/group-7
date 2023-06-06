using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {

        protected readonly AppDbContext Db;
        protected readonly DbSet<Produto> DbSet;

        public ProdutoRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Produto>();            
        }
         public IUnitOfWork UnitOfWork => Db;

        public void Add(Produto produto)
        {
            DbSet.Add(produto);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await DbSet.AsNoTracking().OrderBy(on => on.Nome).ToListAsync(); 
        }

        public async Task<Produto?> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Remove(Produto produto)
        {
            DbSet.Remove(produto);
        }

        public void Update(Produto produto)
        {
            DbSet.Update(produto);
        }
    }
}