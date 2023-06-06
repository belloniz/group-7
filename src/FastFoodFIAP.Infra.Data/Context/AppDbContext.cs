
using System.ComponentModel.DataAnnotations;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using FastFoodFIAP.Infra.Data.Mappings;
using GenericPack.Data;
using GenericPack.Mediator;
using GenericPack.Messaging;
using Microsoft.EntityFrameworkCore;

namespace FastFoodFIAP.Infra.Data.Context
{    
    public sealed class AppDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;
        public DbSet<CategoriaProduto>? CategoriasProdutos { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        //public DbSet<ProdutosImagens>? ProdutosImagens { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IMediatorHandler mediatorHandler) :base(options)
        {
             _mediatorHandler = mediatorHandler;

            //https://learn.microsoft.com/en-us/ef/core/querying/tracking
             ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

             //https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.changetracking.changetracker.autodetectchangesenabled?view=efcore-7.0
             ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            //Configura mapeamento
            modelBuilder.ApplyConfiguration(new CategoriasProdutosMap());
            modelBuilder.ApplyConfiguration(new ProdutosMap());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            //await _mediatorHandler.PublishDomainEvents(this).ConfigureAwait(false);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var success = await SaveChangesAsync() > 0;

            return success;
        }

    }
}