using FastFoodFIAP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class ClientesMap: IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");
   
            builder.HasKey(c => c.Id)
                .HasName("PRIMARY");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasMaxLength(100);   

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasMaxLength(1000);            
            
            builder.Property(c => c.Cpf)
                .HasColumnName("cpf");  
        }
    }
}
