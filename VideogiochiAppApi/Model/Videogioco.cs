using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideogiochiAppApi.Model
{
    [Table("Videogioco")]
    public class Videogioco
    {
        [Key]
        [Column("Pk_Id")]
        public int IdVideogioco { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public DateOnly? DataDiRilascio { get; set; }

        public ICollection<VideogiocoProprietario>? VideogiocoProprietario { get; set; } = new List<VideogiocoProprietario>();


    }
}
