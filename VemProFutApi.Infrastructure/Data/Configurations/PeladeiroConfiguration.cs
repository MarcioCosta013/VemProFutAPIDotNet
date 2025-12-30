
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemProFutApi.Domain.Entities;

namespace VemProFutApi.Infrastructure.Data.Configurations
{
    public class PeladeiroConfiguration : IEntityTypeConfiguration<Peladeiro>
    {
        public void Configure(EntityTypeBuilder<Peladeiro> builder)
        {
            builder.ToTable("peladeiro"); // nome da tabela
            builder.HasKey(p => p.Id); // chave primaria

            builder.Property(p => p.Nome) //Coluna da table
            .HasColumnName("nome_peladeiro")
            .HasMaxLength(50)
            .IsRequired(); //NOT NULL

            builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasMaxLength(80)
            .IsRequired();

            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.Property(p => p.Apelido)
            .HasColumnName("apelido_peladeiro")
            .HasMaxLength(30)
            .IsRequired();

            builder.Property(p => p.Descricao)
            .HasColumnName("descricao_peladeiro")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(p => p.WhatsApp)
            .HasColumnName("whatsapp_peladeiro")
            .HasMaxLength(15)
            .IsRequired();

            builder.Property(p => p.PeDominante)
            .HasColumnName("pe_dominante_peladeiro")
            .HasMaxLength(10)
            .IsRequired();

            //Relacionamentos entre entidades
            
            //(1:1)
            builder.HasOne(peladeiro => peladeiro.HistoricoPeladeiro)
                .WithOne(historicoPeladeiro => historicoPeladeiro.Peladeiro)
                .HasForeignKey<Peladeiro>(peladeiro => peladeiro.HistoricoPeladeiroId);

            //Implementacao abaixo fica na config da classe que tem a lista.
            //(1:N) = 1 Peladeiro pode ter N Banimentos(Lista) / 1 Banimento pertence a somente 1 Peladeiro (FK de Peladeiro)
            builder.HasMany(peladeiro => peladeiro.Banimentos) //Banimento é uma lista.
                .WithOne(banimento => banimento.Peladeiro) //Peladeiro é um atributo tipo Peladeiro.
                .HasForeignKey(banimento => banimento.PeladeiroId); //Atributo primitivo long ligado a o tipo acima.

            //(N:N) = Partida tem N Peladeiro / Peladeiros participam de N partidas
            builder.HasMany(peladeiro => peladeiro.Partidas)
                .WithMany(partidas => partidas.Peladeiros)
                .UsingEntity<Dictionary<string, object>>(
                "esta_peladeiro_partidas", //Tabela de juncao | Tabela a parte criada para intermediar
                    j => j.HasOne<Partida>()
                    .WithMany()
                    .HasForeignKey("PartidaId")
                    .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Peladeiro>()
                    .WithMany()
                    .HasForeignKey("PeladeiroId")
                    .OnDelete(DeleteBehavior.Cascade)
                );

            builder.HasMany(p => p.Administra)
                .WithOne(f => f.Administrador)
                .HasForeignKey(f => f.AdmPeladeiro);
        }
    }
}
