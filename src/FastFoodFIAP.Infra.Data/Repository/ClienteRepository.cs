using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class ClienteRepository: IClienteRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<Cliente> DbSet;

        public ClienteRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Cliente>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void CadastrarNovoCliente(Cliente Cliente)
        {
            if (!VerificarSeCpfJaExiste(Cliente.Cpf))
                DbSet.Add(Cliente);
        }

        private bool VerificarSeCpfJaExiste(string cpf)
        {
            bool c = Db.Clientes.Any(x => x.Cpf == cpf);
            return c;
        }

        public async Task<Cliente?> BuscarClientePorCpf(string cpf)
        {
            return await Db.Clientes.FirstOrDefaultAsync(cliente => cliente.Cpf == cpf);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await DbSet.AsNoTracking().OrderBy(on => on.Nome).ToListAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}