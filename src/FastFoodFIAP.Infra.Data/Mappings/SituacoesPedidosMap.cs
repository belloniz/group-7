using FastFoodFIAP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class SituacoesPedidosMap: IEntityTypeConfiguration<SituacaoPedido>
    {
public void Configure(EntityTypeBuilder<SituacaoPedido> builder)
        {            
            builder.ToTable("situacoes_pedidos");
   
            builder.HasKey(c => c.Id)
                .HasName("PRIMARY");

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasMaxLength(50);               
        }

    }
}
