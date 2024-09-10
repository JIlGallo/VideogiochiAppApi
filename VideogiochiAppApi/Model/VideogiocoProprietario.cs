using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideogiochiAppApi.Model
{
    [Table("VideogiocoProprietario")]

    public class VideogiocoProprietario
    {
        [Key]
        public int IdVideogiocoProprietario { get; set; }

        [ForeignKey("Videogioco")]
        public int? IdVideogioco { get; set; }
        public Videogioco? Videogioco { get; set; }

        [ForeignKey("Proprietario")]
        public int? IdProprietario { get; set; }
        public Proprietario? Proprietario { get; set; }


    }
}
