

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemProFutApi.Domain.Entities;

namespace VemProFutApi.Infrastructure.Data.Configurations
{
    public class HistoricoFutConfiguration : IEntityTypeConfiguration<HistoricoFut>
    {
        public void Configure(EntityTypeBuilder<HistoricoFut> builder)
        {
            builder.ToTable("historico_fut");
            builder.HasKey(h => h.Id);

            builder.Property(h => h.GolsTotal)
                .HasColumnName("gols_total_historico_fut")
                .IsRequired();

            builder.Property(h => h.TotalPartidas)
                .HasColumnName("partidas_jogadas_historico_fut")
                .IsRequired();

            builder.Property(h => h.TimeMaisVitorias)
                .HasColumnName("time_mais_vitorias_historico")
                .IsRequired();
        }
    }
}
