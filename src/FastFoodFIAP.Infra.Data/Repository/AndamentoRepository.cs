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
            var andamentosPedido = Db.Andamentos?
                .Where(f => f.PedidoId == andamento.PedidoId && f.SituacaoId < andamento.SituacaoId)
                .ToList();

            if(andamentosPedido != null ) 
                andamentosPedido.ForEach(a => a.Atual = false);

            DbSet.Add(andamento);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<Andamento?> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Update(Andamento andamento)
        {
            DbSet.Update(andamento);
        }
    }
}
