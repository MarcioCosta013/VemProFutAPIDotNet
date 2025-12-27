using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VemProFutApi.Domain.Entities
{
    [Table("editores_fut")]
    public class Editor
    {
        public Editor()
        {
        }

        public Editor(
            long peladeiroId, 
            long futId)
        {
            PeladeiroId = peladeiroId;
            FutId = futId;
        }

        [Key]
        [Column("id_fut")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("fk_peladeiro"), Required]
        public long PeladeiroId { get; set; }

        [ForeignKey("PeladeiroId")]
        public Editor Peladeiro { get; set; }

        [Column("fk_fut"), Required]
        public long FutId { get; set; }

        [ForeignKey("FutId")]
        public Fut Fut { get; set; }
    }
}