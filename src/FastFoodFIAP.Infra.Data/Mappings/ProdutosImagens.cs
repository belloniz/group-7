using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class ProdutosImagens: IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {            
            builder.ToTable("produtos_imagens");
   
            builder.HasKey(c => c.Id)
                .HasName("PRIMARY");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Url)
                .HasColumnName("url")
                .HasMaxLength(300);
        }
    }
}