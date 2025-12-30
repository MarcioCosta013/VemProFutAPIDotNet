

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemProFutApi.Domain.Entities;

namespace VemProFutApi.Infrastructure.Data.Configurations
{
    public class HisotricoPeladeiroConfiguration : IEntityTypeConfiguration<HistoricoPeladeiro>
    {
        public void Configure(EntityTypeBuilder<HistoricoPeladeiro> builder)
        {
            builder.ToTable("historico_peladeiro");
            builder.HasKey(h => h.Id);

            builder.Property(h => h.GolsDoPeladeiro)
                .HasColumnName("gols_historico_peladeiro")
                .IsRequired();

            builder.Property(h => h.NotaDoPeladeiro)
                .HasColumnName("nota_historico_peladeiro")
                .IsRequired();

            builder.Property(h => h.PartidasJogadas)
                .HasColumnName("partidas_jogadas_peladeiro")
                .IsRequired();

            builder.Property(h => h.PartidasGanhas)
                .HasColumnName("partidas_ganhas_peladeiro")
                .IsRequired();
        }
    }
}
