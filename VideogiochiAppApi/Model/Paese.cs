using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideogiochiAppApi.Model
{
    [Table("Paese")]
    public class Paese
    {
        [Key]
        [Column("Pk_Id")]
        public int IdPaese { get; set; }

        [Required]
        public string? Name { get; set; }


        public ICollection<Proprietario>? Proprietario { get; set; }
    }
}
