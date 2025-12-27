using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VemProFutApi.Domain.Entities
{
    [Table("fut")]
    public class Fut
    {
        public Fut()
        {
            //Construtor padrao
            Editores = new List<Editor>();
            Peladeiros = new List<Peladeiro>();
            Cartaos = new List<Cartao>();
            Banimentos = new List<Banimento>();

        }

        public Fut(
            string nome, 
            int jogadoresPorTime, 
            int tempoMaxPartida, 
            int maxGolsVitoria, 
            string foto_Url, 
            long? historicoFutId, 
            HistoricoFut? historicoFut, 
            Peladeiro? admin)
        {
            Nome = nome;
            JogadoresPorTime = jogadoresPorTime;
            TempoMaxPartida = tempoMaxPartida;
            MaxGolsVitoria = maxGolsVitoria;
            Foto_Url = foto_Url;
            HistoricoFutId = historicoFutId;
            HistoricoFut = historicoFut;
            Admin = admin;
        }

        [Key]
        [Column("id_fut")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("nome_fut"), Required, StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Column("jogadores_por_time_fut"), Required]
        public int JogadoresPorTime { get; set; }

        [Column("tempo_max_partida_fut"), Required]
        public int TempoMaxPartida { get; set; }

        [Column("max_gols_vitoria_fut"), Required]
        public int MaxGolsVitoria { get; set; }

        [Column("foto_url")]
        public string Foto_Url { get; set; } = string.Empty;

        [Column("fk_historico_peladeiro")]
        public long? HistoricoFutId { get; set; }

        [Column("fk_peladeiro")]
        public long? AdmPeladeiro { get; set; }

        [ForeignKey("HistoricoFutId")]
        public HistoricoFut? HistoricoFut { get; set; }

        [ForeignKey("AdmPeladeiro")]
        public Peladeiro? Administrador { get; set; }

        public Peladeiro? Admin { get; set; }

        public ICollection<Peladeiro> Peladeiros { get; set; }
        public ICollection<Editor> Editores { get; set; }
        public ICollection<Cartao> Cartaos { get; set; } 
        public ICollection<Banimento> Banimentos { get; set; }

        public void AddPeladeiro(Peladeiro peladeiro)
        {
            Peladeiros.Add(peladeiro);
            peladeiro.Futs.Add(this);
        }

        public void AddBanimento(Banimento banimento)
        {
            Banimentos.Add(banimento);
            banimento.AddFut(this);
        }
    }
}