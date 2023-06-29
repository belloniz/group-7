using FastFoodFIAP.Domain.Models.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class PedidosCombosMap : IEntityTypeConfiguration<PedidoCombo>
    {
        public void Configure(EntityTypeBuilder<PedidoCombo> builder)
        {
            builder.ToTable("pedidos_combos");

            builder.HasKey(c => c.Id)
                .HasName("PRIMARY");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Quantidade)
                .HasColumnName("quantidade");

            builder.Property(c => c.PedidoId)
                .HasColumnName("pedido_id");

            builder.HasIndex(c => c.PedidoId);

            builder.HasOne(c => c.PedidoNavegation)
                .WithMany(p => p.Combos)
                .HasForeignKey(p => p.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(e => e.Produtos).AutoInclude();
        }
    }
}
