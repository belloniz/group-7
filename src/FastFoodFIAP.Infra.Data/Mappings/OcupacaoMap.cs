using FastFoodFIAP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class OcupacaoMap : IEntityTypeConfiguration<Ocupacao>
    {
        public void Configure(EntityTypeBuilder<Ocupacao> builder)
        {            
            builder.ToTable("ocupacao");
   
            builder.HasKey(c => c.Id)
                .HasName("PRIMARY");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasMaxLength(50);            
        }
    }
}
