using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class SituacaoPagamentoRepository: ISituacaoPagamentoRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<SituacaoPagamento> DbSet;

        public SituacaoPagamentoRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<SituacaoPagamento>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<SituacaoPagamento>> GetAll()
        {
            return await DbSet.AsNoTracking().OrderBy(on => on.Id).ToListAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}