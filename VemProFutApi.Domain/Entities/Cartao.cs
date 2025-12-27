using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VemProFutApi.Domain.Enuns;

namespace VemProFutApi.Domain.Entities
{
    [Table("cartoes_peladeiro")]
    public class Cartao
    {
        public Cartao()
        {
        }

        public Cartao(
            long partidaId,
            long peladeiroId, 
            long futId, 
            TipoCartao tipoCartao)
        {
            PartidaId = partidaId;
            PeladeiroId = peladeiroId;
            FutId = futId;
            TipoCartao = tipoCartao;
        }



        [Key]
        [Column("id_cartoes_peladeiro")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("fk_partida")]
        public long PartidaId { get; set; }

        [ForeignKey("PartidaId")]
        public Partida? Partida { get; set; }

        [Column("fk_peladeiro")]
        public long PeladeiroId { get; set; }

        [ForeignKey("PeladeiroId")]
        public Peladeiro Peladeiro { get; set; }

        [Column("fk_fut")]
        public long FutId { get; set; }

        [ForeignKey("FutId")]
        public Fut Fut { get; set; }

        [Column("tipoCartao")]
        public TipoCartao TipoCartao { get; set; }

    }
}