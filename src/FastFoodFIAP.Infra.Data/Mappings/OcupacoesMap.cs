using FastFoodFIAP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class OcupacoesMap : IEntityTypeConfiguration<Ocupacao>
    {
        public void Configure(EntityTypeBuilder<Ocupacao> builder)
        {            
            builder.ToTable("ocupacoes");
   
            builder.HasKey(o => o.Id)
                .HasName("PRIMARY");

            builder.Property(o => o.Id)
                .HasColumnName("id");

            builder.Property(o => o.Nome)
                .HasColumnName("nome")
                .HasMaxLength(50);            
        }
    }
}
