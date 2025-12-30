

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemProFutApi.Domain.Entities;

namespace VemProFutApi.Infrastructure.Data.Configurations
{
    public class FutConfiguration : IEntityTypeConfiguration<Fut>
    {
        public void Configure(EntityTypeBuilder<Fut> builder)
        {
            builder.ToTable("fut");
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .HasColumnName("nome_fut")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(f => f.Nome)
                .IsUnique();

            builder.Property(f => f.JogadoresPorTime)
                .HasColumnName("jogadores_por_time_fut")
                .IsRequired();

            builder.Property(f => f.TempoMaxPartida)
                .HasColumnName("tempo_max_partida_fut")
                .IsRequired();

            builder.Property(f => f.MaxGolsVitoria)
                .HasColumnName("max_gols_vitoria_fut")
                .IsRequired();

            builder.Property(f => f.Foto_Url)
                .HasColumnName("foto_url")
                .IsRequired();

            //Relacionamentos
            builder.HasOne(fut => fut.HistoricoFut)
                .WithOne(historicoFut => historicoFut.Fut)
                .HasForeignKey<Fut>(fut => fut.HistoricoFutId); //1:1

            builder.HasMany(fut => fut.Peladeiros)
                .WithMany(p => p.Futs)
                .UsingEntity<Dictionary<string, object>>(
                "participa_peladeiro_fut", // tabela de junção
                j => j.HasOne<Peladeiro>()
                      .WithMany()
                      .HasForeignKey("PeladeiroId")
                      .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Fut>()
                      .WithMany()
                      .HasForeignKey("FutId")
                      .OnDelete(DeleteBehavior.Cascade)
                );


        }
    }
}
