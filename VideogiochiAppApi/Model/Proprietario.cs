using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideogiochiAppApi.Model
{
    [Table("Proprietario")]
    public class Proprietario
    {
        [Key]
        [Column("Pk_Id")]
        public int IdProprietario { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public int? Età { get; set; }

        [ForeignKey("Paese")]
        public int? IdPaese { get; set; }
        public Paese? Paese { get; set; }

        public ICollection<VideogiocoProprietario>? VideogiocoProprietario { get; set; } = new List<VideogiocoProprietario>();
    }
}
