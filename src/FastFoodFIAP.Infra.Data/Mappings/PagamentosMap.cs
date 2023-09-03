using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class PagamentosMap: IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("pagamentos");
   
            builder.HasKey(p => p.Id)
                .HasName("PRIMARY");

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.QrCode)
                .HasColumnName("qr_code")
                .HasMaxLength(300);

            builder.Property(c => c.Valor)
                .HasColumnName("valor");

            builder.Property(c => c.PedidoId)
                .HasColumnName("pedido_id");            

            builder.HasIndex(c => c.PedidoId);

            builder.HasOne(c => c.PedidoNavegation)
                .WithOne(p => p.PagamentoNavegation)
                .HasForeignKey<Pagamento>();

            builder.Property(c => c.SituacaoId)
                .HasColumnName("situacao_id");

            builder.HasIndex(c => c.SituacaoId);

            builder.HasOne(c => c.SitucaoPagamentoNavegation)
               .WithMany()
               .HasForeignKey(p => p.SituacaoId);
            
            builder.Navigation(e => e.SitucaoPagamentoNavegation).AutoInclude();
        }
    }
}
