using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VemProFutApi.Domain.Entities
{
    [Table("historico_fut")]
    public class HistoricoFut
    {

        [Key]
        [Column("id_historico_fut")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("gols_total_historico_fut")]
        public int GolsTotal { get; set; }

        [Column("partidas_jogadas_historico_fut")]
        public int TotalPartidas { get; set; }

        [Column("time_mais_vitorias_historico")]
        public string TimeMaisVitorias = "vazio";
    }
}