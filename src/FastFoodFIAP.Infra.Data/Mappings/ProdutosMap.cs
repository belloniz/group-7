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

            builder.Property(c => c.Id)
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
                .HasColumnName("categoria_id");  
            
            builder.HasIndex(c => c.CategoriaId);

            builder.HasOne(c => c.CategoriaNavegation)
                .WithMany(p => p.Produtos)
                .HasForeignKey(p => p.CategoriaId);            
            
            builder.Navigation(e => e.CategoriaNavegation).AutoInclude();
            builder.Navigation(e => e.Imagens).AutoInclude();
        }
    }
}

