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
        
        public async Task<Pedido?> GetById(int id)
        {
            return await DbSet.FindAsync(id);
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
            // var imagens = Db.PedidosImagens!.Where(p => p.PedidoId == pedido.Id).AsNoTracking();
            // if (imagens != null) 
            //     Db.PedidosImagens!.RemoveRange(imagens);

            DbSet.Update(pedido);          
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
