using FastFoodFIAP.Domain.Interfaces;
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

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await DbSet.AsNoTracking().OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetAllByCategoria(Guid categoriaId){
            return await DbSet.AsNoTracking().Where(x => x.CategoriaId == categoriaId).OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Produto?> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public void Add(Produto produto)
        {
            DbSet.Add(produto);        
        }

        public void Remove(Produto produto)
        {
            DbSet.Remove(produto);
        }

        public void Update(Produto produto)
        {
            var imagens = Db.ProdutosImagens!.Where(p => p.ProdutoId == produto.Id).AsNoTracking();
            if (imagens != null) 
                Db.ProdutosImagens!.RemoveRange(imagens);

            DbSet.Update(produto);          
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
