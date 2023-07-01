using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class PedidoRepository: IPedidoRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<Pedido> DbSet;

        public PedidoRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Pedido>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> GetAllBySituacao(int situacaoId)
        {
            return await DbSet.AsNoTracking()
                .Where(c => c.Andamentos
                .Any(a => a.SituacaoId == situacaoId && a.Atual))
                .ToListAsync();          
        }

        public async Task<Pedido?> GetById(int id)
        {
            return await DbSet.FindAsync(id); ;
        }

        public void Add(Pedido pedido)
        {
            DbSet.Add(pedido);        
        }

        public void Remove(Pedido pedido)
        {
            DbSet.Remove(pedido);
        }

        public void Update(Pedido pedido)
        {
            var combos = Db.PedidosCombos!.Where(p => p.PedidoId == pedido.Id).AsNoTracking();
            if (combos != null) 
                Db.PedidosCombos!.RemoveRange(combos);

            DbSet.Update(pedido);          
        }

        public void Dispose()
        {
            Db.Dispose();
        }        
    }
}
