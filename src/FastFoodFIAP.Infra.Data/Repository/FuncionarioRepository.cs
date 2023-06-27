using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class PagamentoRepository: IPagamentoRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<Pagamento> DbSet;

        public PagamentoRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Pagamento>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<Pagamento>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }
        
        public async Task<Pagamento?> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(Pagamento pagamento)
        {
            DbSet.Add(pagamento);        
        }

        public void Remove(Pagamento pagamento)
        {
            DbSet.Remove(pagamento);
        }

        public void Update(Pagamento pagamento)
        {
            DbSet.Update(pagamento);          
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}