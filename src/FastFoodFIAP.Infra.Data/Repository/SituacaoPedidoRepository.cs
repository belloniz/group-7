using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class SituacaoPedidoRepository: ISituacaoPedidoRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<SituacaoPedido> DbSet;

        public SituacaoPedidoRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<SituacaoPedido>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<SituacaoPedido>> GetAll()
        {
            return await DbSet.AsNoTracking().OrderBy(on => on.Id).ToListAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}