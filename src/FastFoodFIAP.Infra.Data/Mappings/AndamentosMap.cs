using FastFoodFIAP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class AndamentosMap : IEntityTypeConfiguration<Andamento>
    {
        public void Configure(EntityTypeBuilder<Andamento> builder)
        {
            builder.ToTable("pedidos_andamentos");

            builder.HasKey(c => c.Id)
                .HasName("PRIMARY");

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.PedidoId)
                .HasColumnName("pedido_id");

            builder.HasIndex(c => c.PedidoId);

            builder.HasOne(c => c.PedidoNavegation)
               .WithMany(p => p.Andamentos)
               .HasForeignKey(p => p.PedidoId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.DataHoraInicio)
                .HasColumnName("data_hora_inicio");

            builder.Property(c => c.DataHoraFim)
                .HasColumnName("data_hora_fim");

            builder.Property(c => c.Atual)
                .HasColumnName("atual");

            builder.Property(c => c.SituacaoId)
                .HasColumnName("situacao_id");

            builder.HasIndex(c => c.SituacaoId);

            builder.HasOne(c => c.SitucaoPedidoNavegation)
               .WithMany()
               .HasForeignKey(p => p.SituacaoId);

            builder.Property(c => c.FuncionarioId)
                .HasColumnName("funcionario_id");

            builder.HasIndex(c => c.FuncionarioId);

            builder.HasOne(c => c.FuncionarioNavegation)
                .WithMany()
                .HasForeignKey(p => p.FuncionarioId);

            builder.Navigation(e => e.SitucaoPedidoNavegation).AutoInclude();
            builder.Navigation(e => e.FuncionarioNavegation).AutoInclude();
        }
    }
}
