
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemProFutApi.Domain.Entities;

namespace VemProFutApi.Infrastructure.Data.Configurations
{
    public class GolPartidaConfiguration : IEntityTypeConfiguration<GolPartida>
    {
        public void Configure(EntityTypeBuilder<GolPartida> builder)
        {
            builder.ToTable("gols_partida");
            builder.HasKey(g => g.Id);

            builder.HasOne(g => g.Peladeiro)
                .WithMany(p => p.GolsPeladeiro)
                .HasForeignKey(g => g.PeladeiroId);

            builder.HasOne(g => g.Partida)
                .WithMany(p => p.GolPartida)
                .HasForeignKey(g => g.PartidaId);
        }
    }
}
