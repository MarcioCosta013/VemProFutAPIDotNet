using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VemProFutApi.Domain.Entities
{
    [Table("historico_peladeiro")]
    public class HistoricoPeladeiro
    {
        [Key]
        [Column("id_historico_fut")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("gols_total_historico_fut")]
        public int GolsDoPeladeiro = 0;

        [Column("nota_historico_peladeiro")]
        public double NotaDoPeladeiro = 0.0;

        [Column("partidas_jogadas_peladeiro")]
        public int PartidasJogadas = 0;

        [Column("partidas_ganhas_peladeiro")]
        public int PartidasGanhas = 0;
    }
}