using Microsoft.AspNetCore.Mvc;
using VideogiochiAppApi.Interfaces;
using VideogiochiAppApi.Model;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace VideogiochiAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideogiocoController : Controller
    {
        private readonly IVideogiocoRepository videogiocoRepository;

        public VideogiocoController(IVideogiocoRepository videogiocoRepository)
        {
            this.videogiocoRepository = videogiocoRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof (IEnumerable<Videogioco>))]
        public IActionResult GetVideogiochi()
        {
            var videogiochi = videogiocoRepository.GetVideogiochi();
            // ModelState.IsValid viene utilizzato per la validazione del modello in scenari in cui si ricevono dati dal client.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(videogiochi);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Videogioco))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVideogioco(int id)
        {
            var idVid = videogiocoRepository.GetVideogioco(id);
            if (idVid == null)
            {
                return NotFound();
            }
            return Ok(idVid);

        }

    }
}
