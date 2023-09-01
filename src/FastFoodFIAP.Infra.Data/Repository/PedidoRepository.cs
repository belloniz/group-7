using Dapper;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Models.Enums;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class PedidoRepository: IPedidoRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<Pedido> DbSet;
        public readonly IDbConnection Connection;

        public PedidoRepository(AppDbContext context, IDbConnection connection)
        {
            Db = context;
            DbSet = Db.Set<Pedido>();

            Connection = connection;
            Connection.ConnectionString = Db.Database.GetConnectionString();
        }
        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> GetAllAtivos()
        {
            try
            {
                //return await DbSet.AsNoTracking()
                //.Include(x => x.Andamentos!
                //.OrderByDescending(x => x.SituacaoId).ThenBy(x => x.DataHoraInicio))
                //.Where(x => x.Andamentos!
                //.Any(x => x.Atual && x.SituacaoId <= (int)Domain.Models.Enums.SituacaoPedido.Pronto))
                //.ToListAsync();


                var query = from p in Db.Pedidos
                            join pc in Db.PedidosCombos! on p.Id equals pc.PedidoId
                            join pcp in Db.PedidosCombosProdutos! on pc.Id equals pcp.PedidoComboId
                            join pd in Db.Produtos! on pcp.ProdutoId equals pd.Id
                            join c in Db.CategoriasProdutos! on pd.CategoriaId equals c.Id
                            join a in Db.Andamentos! on p.Id equals a.PedidoId
                            join s in Db.SituacoesPedidos! on a.SituacaoId equals s.Id
                            from f in Db.Funcionarios.Where(f => a.FuncionarioId == f.Id).DefaultIfEmpty()
                            from cl in Db.Clientes.Where(cl => p.ClienteId == cl.Id).DefaultIfEmpty()
                            where s.Id <= (int)Domain.Models.Enums.SituacaoPedido.Pronto && a.Atual
                            orderby s.Id descending
                            select p;

                //var query = from p in Db.Pedidos
                //            join pc in Db.PedidosCombos on p.Id equals pc.PedidoId
                //            join pcp in Db.PedidosCombosProdutos on pc.Id equals pcp.PedidoComboId
                //            join pd in Db.Produtos on pcp.ProdutoId equals pd.Id
                //            join c in Db.CategoriasProdutos on pd.CategoriaId equals c.Id
                //            join a in Db.Andamentos on p.Id equals a.PedidoId
                //            join s in Db.SituacoesPedidos on a.SituacaoId equals s.Id
                //            join f in Db.Funcionarios on a.FuncionarioId equals f.Id into fGroup
                //            from f in fGroup.DefaultIfEmpty()
                //            join cl in Db.Clientes on p.ClienteId equals cl.Id into clGroup
                //            from cl in clGroup.DefaultIfEmpty()
                //            where s.Id <= 3 && a.Atual
                //            orderby s.Id descending
                //            select new
                //            {
                //                Pedido = p,
                //                Cliente = cl,
                //                PedidoCombo = pc,
                //                PedidoComboProduto = pcp,
                //                Produto = pd,
                //                CategoriaProduto = c,
                //                AndamentoPedido = a,
                //                SituacaoPedido = s,
                //                Funcionario = f
                //            };

                var result = query.ToList();
                return (IEnumerable<Pedido>)result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Pedido>> GetAllBySituacao(int situacaoId)
        {
            return await DbSet.AsNoTracking()
                .Where(c => c.Andamentos!
                .Any(a => a.SituacaoId == situacaoId && a.Atual))
                .ToListAsync();          
        }

        public async Task<Pedido?> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().FirstAsync(x => x.Id == id);
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

        public bool PagamentoAprovado(Guid id)
        {
            Andamento? andamento = Db.Andamentos?.Where(x => x.PedidoId.Equals(id) && x.DataHoraFim != null  && x.SituacaoId == (int)Domain.Models.Enums.SituacaoPedido.Recebido)
                .FirstOrDefault();

            return andamento != null;
        }
    }
}
