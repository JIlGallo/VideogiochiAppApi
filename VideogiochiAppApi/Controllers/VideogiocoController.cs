using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideogiochiAppApi.Dto;
using VideogiochiAppApi.Interfaces;
using VideogiochiAppApi.Model;
using VideogiochiAppApi.Repository;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace VideogiochiAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideogiocoController : Controller
    {
        private readonly IProprietarioRepository proprietarioRepository;

        private readonly IVideogiocoRepository videogiocoRepository;
        private readonly IMapper mapper;

        public VideogiocoController(IVideogiocoRepository videogiocoRepository, IMapper mapper, IProprietarioRepository proprietarioRepository)
        {
            this.videogiocoRepository = videogiocoRepository;
            this.mapper = mapper;
            this.proprietarioRepository = proprietarioRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof (IEnumerable<VideogiocoDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVideogiochi()
        {
            var videogiochi = videogiocoRepository.GetVideogiochi();
            var videogiochiDto = mapper.Map<IEnumerable<VideogiocoDto>>(videogiochi);
            // ModelState.IsValid viene utilizzato per la validazione del modello in scenari in cui si ricevono dati dal client.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(videogiochiDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(VideogiocoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVideogioco(int id)
        {
            var idVid = videogiocoRepository.GetVideogioco(id);
            var idVidGiusto = mapper.Map<VideogiocoDto>(idVid);
            if (idVidGiusto == null)
            {
                return NotFound();
            }
            return Ok(idVidGiusto);
        }
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(VideogiocoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateVideogioco([FromQuery] int proprietarioId, [FromBody] VideogiocoDto videogiocoCreazione)
        {
            // Verifica se il DTO del videogioco è null
            if (videogiocoCreazione == null)
            {
                return BadRequest("I dati forniti non sono validi.");
            }

            // Mappa il DTO al modello di dominio Videogioco
            var videogioco = mapper.Map<Videogioco>(videogiocoCreazione);

            // Verifica se il proprietario esiste
            var proprietario = proprietarioRepository.GetProprietario(proprietarioId);
            if (proprietario == null)
            {
                return NotFound("Proprietario non trovato.");
            }

            // Aggiungi l'associazione many-to-many
            videogioco.VideogiocoProprietario = new List<VideogiocoProprietario>
    {
        new VideogiocoProprietario { Proprietario = proprietario, Videogioco = videogioco }
    };

            // Prova a creare il videogioco
            if (!videogiocoRepository.CreateVideogioco(proprietarioId,videogioco))
            {
                ModelState.AddModelError("", "Qualcosa è andato storto durante la creazione del videogioco.");
                return StatusCode(500, ModelState);
            }

            // Ritorna l'azione creata con il percorso e il DTO originale
            return CreatedAtAction(nameof(GetVideogioco), new { id = videogioco.IdVideogioco }, videogiocoCreazione);
        }
        [HttpPut("{videogiocoId}")]
        [ProducesResponseType(200, Type = typeof(VideogiocoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVideogioco(int videogiocoId, [FromQuery] int proprietarioId, [FromBody] VideogiocoDto updateVideogioco)
        {
            if (updateVideogioco == null)
            {
                return BadRequest("Dati forniti non correttamente");
            }
            if (videogiocoId != updateVideogioco.IdVideogioco)
            {
                return BadRequest("Non coincide");
            }
            var videogiocoMap = mapper.Map<Videogioco>(updateVideogioco);

            if (!videogiocoRepository.UpdateVideogioco(proprietarioId,videogiocoMap))
            {
                return StatusCode(500);
            }
            return NoContent();
        }
        [HttpDelete("{videogiocoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteVideogioco(int videogiocoId)
        {

            var videogiocoToDelete = videogiocoRepository.GetVideogioco(videogiocoId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!videogiocoRepository.DeleteVideogioco(videogiocoToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }







    }
}
