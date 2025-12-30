

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemProFutApi.Domain.Entities;

namespace VemProFutApi.Infrastructure.Data.Configurations
{
    public class PartidaConfiguration : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.ToTable("partidas");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.reservas)
                .HasColumnName("reservas_partida")
                .IsRequired();

            builder.HasOne(p => p.Fut)
                .WithMany(f => f.Partidas)
                .HasForeignKey(p => p.FutId);
        }
    }
}
