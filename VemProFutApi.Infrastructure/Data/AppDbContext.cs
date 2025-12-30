using Microsoft.EntityFrameworkCore;
using VemProFutApi.Domain.Entities;

namespace VemProFutApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //DbSets:  dentro dele corresponde a uma tabela no banco
        public DbSet<Peladeiro> Peladeiros {get; set;}
        public DbSet<Banimento> Banimentos {get; set;}
        public DbSet<Partida> Partidas {get; set; }
        public DbSet<Editor> Editors {get; set;}
        public DbSet<Fut> Futs { get; set; }
        public DbSet<Cartao> Cartaos { get; set; }
        public DbSet<GolPartida> Gols { get; set; }
        public DbSet<HistoricoFut> HistoricoFuts { get; set; }
        public DbSet<HistoricoPeladeiro> HistoricoPeladeiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica todas as configurações automaticamente
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
