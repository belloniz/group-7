
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class OcupacaoRepository : IOcupacaoRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<Ocupacao> DbSet;

        public OcupacaoRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Ocupacao>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Add(Ocupacao ocupacao)
        {
            DbSet.Add(ocupacao);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<Ocupacao>> GetAll()
        {
            return await DbSet.AsNoTracking().OrderBy(on => on.Nome).ToListAsync();
        }

        public async Task<Ocupacao?> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Remove(Ocupacao ocupacao)
        {
            DbSet.Remove(ocupacao);
        }

        public void Update(Ocupacao ocupacao)
        {
            DbSet.Update(ocupacao);
        }
    }
}
