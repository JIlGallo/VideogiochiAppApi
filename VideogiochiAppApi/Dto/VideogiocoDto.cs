using System.ComponentModel.DataAnnotations;

namespace VideogiochiAppApi.Dto
{
    public class VideogiocoDto
    {
        public int IdVideogioco { get; set; }

        public string? Nome { get; set; }

        public DateOnly? DataDiRilascio { get; set; }

    }
}
