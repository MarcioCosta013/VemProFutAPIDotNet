using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VemProFutApi.Domain.Entities
{
    [Table("gols_partida")]
    public class GolPartida
    {


        public GolPartida()
        {
        }

        public GolPartida(
            long peladeiroId, 
            long partidaId)
        {
            PeladeiroId = peladeiroId;
            PartidaId = partidaId;
        }

        [Key]
        [Column("id_gols_partida")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id;

        [Column("fk_peladeiro"), Required]
        public long PeladeiroId { get; set; }

        [ForeignKey("PeladeiroId")]
        public Peladeiro Peladeiro { get; set; }

        [Column("fk_partida")]
        public long PartidaId { get; set; }

        [ForeignKey("PartidaId")]
        public Partida Partida { get; set; }
    }
}