using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VemProFutApi.Domain.Entities
{
    [Table("banimento")]
    public class Banimento
    {
        public Banimento(string motivo, 
            DateOnly dataBanimento, 
            DateOnly dataFimBanimento, 
            long? peladeiroId, 
            long? futId)
        {
            Motivo = motivo;
            DataBanimento = dataBanimento;
            DataFimBanimento = dataFimBanimento;
            PeladeiroId = peladeiroId;
            FutId = futId;
        }

        [Key]
        [Column("id_banimento")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("motivo_banimento"), Required, StringLength(50)]
        public string Motivo { get; set; } = String.Empty;

        [Column("data_banimento"), Required]
        public DateOnly DataBanimento { get; set; }

        [Column("data_fim_banimento"), Required]
        public DateOnly DataFimBanimento { get; set; }

        [Column("fk_peladeiro"), Required]
        public long? PeladeiroId { get; set; }

        [Column("fk_fut"), Required]
        public long? FutId { get; set; }

        [ForeignKey("PeladeiroId")]
        public Peladeiro? Peladeiro { get; set; }

        [ForeignKey("FutId")]
        public Fut? Fut { get; set; }

        //Helpers
        public void AddFut (Fut fut)
        {
            Fut = fut;
            fut.AddBanimento(this);
        }

        public void AddPeladeiro(Peladeiro peladeiro)
        {
            Peladeiro = peladeiro;
            peladeiro.AddBanimento(this);
        }
    }
}