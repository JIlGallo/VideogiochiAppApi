using System.ComponentModel.DataAnnotations;
using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Dto
{
    public class ProprietarioDto
    {
        public int IdProprietario { get; set; }

        public string? Nome { get; set; }

        public int? Età { get; set; }

        public ICollection<VideogiocoProprietario>? VideogiocoProprietario { get; set; } = new List<VideogiocoProprietario>();

    }
}
