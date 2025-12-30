

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemProFutApi.Domain.Entities;

namespace VemProFutApi.Infrastructure.Data.Configurations
{
    public class CartaoConfiguration : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("cartoes_peladeiro");
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Partida)
                .WithMany(p => p.Cartaos)
                .HasForeignKey(c => c.PartidaId);

            builder.HasOne(c => c.Peladeiro)
                .WithMany(p => p.Cartoes)
                .HasForeignKey(c => c.PeladeiroId);

            builder.HasOne(c => c.Fut)
                .WithMany(f => f.Cartaos)
                .HasForeignKey(c => c.FutId);

            builder.Property(c => c.TipoCartao)
                .HasColumnName("tipoCartao")
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}