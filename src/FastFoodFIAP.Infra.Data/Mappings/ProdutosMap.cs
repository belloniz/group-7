using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class ProdutosMap: IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {            
            builder.ToTable("produtos");
   
            builder.HasKey(c => c.Id)
                .HasName("PRIMARY");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasMaxLength(100);   

            builder.Property(c => c.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(1000);            
            
            builder.Property(c => c.Preco)
                .HasColumnName("preco");  

            builder.Property(c => c.CategoriaId)
                .HasColumnName("categoriaid");  

            builder.HasOne(e => e.CategoriaNavegation)
                .WithMany(p => p.Produtos)
                .HasForeignKey(d => d.CategoriaId);

            // builder.HasMany(p => p.Imagens)
            //     .WithOne(e => e.ProdutoNavigation)
            //     .HasForeignKey(p => p.Id)
            //     .OnDelete(DeleteBehavior.Cascade);   

            builder.Navigation(e => e.CategoriaNavegation).AutoInclude();
        }
    }
}