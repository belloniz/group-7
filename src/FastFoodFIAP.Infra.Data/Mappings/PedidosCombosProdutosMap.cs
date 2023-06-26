using FastFoodFIAP.Domain.Models.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class PedidosCombosProdutosMap : IEntityTypeConfiguration<PedidoComboProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoComboProduto> builder)
        {
            builder.ToTable("pedidos_combos_produtos");

            builder.HasKey(c => c.Id)
                .HasName("PRIMARY");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Quantidade)
                .HasColumnName("quantidade");

            builder.Property(c => c.ValorUnitario)
                .HasColumnName("valor_unitario");

            builder.Property(c => c.PedidoComboId)
                .HasColumnName("combo_id");

            builder.HasIndex(c => c.PedidoComboId);

            //builder.HasOne(c => c.PedidoComboNavigation)
            //    .WithOne(p => p.PedidoComboProduto);

            builder.Property(c => c.ProdutoId)
                .HasColumnName("produto_id");

            builder.HasIndex(c => c.ProdutoId);

            builder.HasOne(c => c.ProdutoNavigation)
                .WithMany()
                .HasForeignKey(c => c.ProdutoId);

        }
    }
}
