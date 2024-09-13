using System.ComponentModel.DataAnnotations;
using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Dto
{
    public class VideogiocoDto
    {
        public int IdVideogioco { get; set; }

        public string? Nome { get; set; }

        public DateOnly? DataDiRilascio { get; set; }


    }
}
