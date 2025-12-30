using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemProFutApi.Domain.Entities;

namespace VemProFutApi.Infrastructure.Data.Configurations
{
    public class BanimentoConfiguration : IEntityTypeConfiguration<Banimento>
    {
        public void Configure(EntityTypeBuilder<Banimento> builder)
        {
            builder.ToTable("banimento");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Motivo)
                .HasColumnName("motivo_banimento")
                .IsRequired();

            builder.Property(b => b.DataBanimento)
                .HasColumnName("data_banimento")
                .IsRequired();

            builder.Property(b => b.DataFimBanimento)
                .HasColumnName("data_fim_banimento")
                .IsRequired();

            builder.HasOne(b => b.Peladeiro)
                .WithMany(p => p.Banimentos)
                .HasForeignKey(b => b.PeladeiroId);

            builder.HasOne(b => b.Fut)
                .WithMany(f => f.Banimentos)
                .HasForeignKey(b => b.FutId);
        }
    }
}
