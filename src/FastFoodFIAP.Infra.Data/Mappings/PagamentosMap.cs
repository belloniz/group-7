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
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.QrCode)
                .HasColumnName("qrcode")
                .HasMaxLength(100);

            builder.Property(c => c.Valor)
                .HasColumnName("valor");
        }
    }
}