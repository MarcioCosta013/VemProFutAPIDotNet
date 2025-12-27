using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VemProFutApi.Domain.Entities
{
    [Table("partidas")]
    public class Partida
    {
        public Partida(
            bool reservas, 
            long futId, 
            ICollection<Cartao> cartaos, 
            ICollection<GolPartida> golPartida, 
            ICollection<Peladeiro> peladeiro
            )
        {
            this.reservas = reservas;
            FutId = futId;
            Cartaos = cartaos;
            GolPartida = golPartida;
            Peladeiro = peladeiro;
        }

        [Key]
        [Column("id_partida")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("reservas_partida"), Required]
        public bool reservas { get; set; }

        [Column("fk_fut")]
        public long FutId { get; set; }

        [ForeignKey("FutId")]
        public Fut Fut { get; set; }

        public ICollection<Cartao> Cartaos { get; set; }

        public ICollection<GolPartida> GolPartida { get; set; }

        public ICollection<Peladeiro> Peladeiro { get; set; }

        //Helpers
        public void AddPeladeiro(Peladeiro peladeiro)
        {
            Peladeiro.Add(peladeiro);
            peladeiro.AddPartida(this);
        }
    }

}