using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class AndamentoRepository:IAndamentoRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<Andamento> DbSet;

        public AndamentoRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Andamento>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Add(Andamento andamento)
        {
            DbSet.Add(andamento);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<Andamento?> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Update(Andamento andamento)
        {
            DbSet.Update(andamento);
        }

        public async Task<IEnumerable<Andamento>> GetAllByPedido(Guid pedidoId){
            return await DbSet.AsNoTracking().Where(x => x.PedidoId == pedidoId).ToListAsync();
        }
    }
}
