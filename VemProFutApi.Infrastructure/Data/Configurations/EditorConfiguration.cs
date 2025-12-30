

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemProFutApi.Domain.Entities;

namespace VemProFutApi.Infrastructure.Data.Configurations
{
    public class EditorConfiguration : IEntityTypeConfiguration<Editor>
    {
        public void Configure(EntityTypeBuilder<Editor> builder)
        {
            builder.ToTable("editores_fut");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Peladeiro)
                .WithMany(p => p.Editores)
                .HasForeignKey(e => e.PeladeiroId);

            builder.HasOne(e => e.Fut)
                .WithMany(f => f.Editores)
                .HasForeignKey(e => e.FutId);
        }
    }
}
