using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Dto
{
    public class ProprietarioDto
    {
        public int IdProprietario { get; set; }

        public string? Nome { get; set; }

        public int? Età { get; set; }
        //[JsonIgnore]
        //public ICollection<VideogiocoProprietario>? VideogiocoProprietario { get; set; } = new List<VideogiocoProprietario>();
        public int? IdPaese { get; set; }

    }
}
