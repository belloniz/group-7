using FastFoodFIAP.Domain.Models.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class PedidosMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedidos");
   
            builder.HasKey(c => c.Id)
                .HasName("PRIMARY");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            

            builder.Property(c => c.ClienteId)
                .HasColumnName("cliente_id");  
            
            builder.HasIndex(c => c.ClienteId);

            builder.HasOne(c => c.ClienteNavegation)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(p => p.ClienteId);            
            
            //builder.Navigation(e => e.ClienteNavegation).AutoInclude();
            //builder.Navigation(e => e.Imagens).AutoInclude();
        }
    }
}
