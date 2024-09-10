using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideogiochiAppApi.Dto;
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
        private readonly IMapper mapper;

        public VideogiocoController(IVideogiocoRepository videogiocoRepository, IMapper mapper)
        {
            this.videogiocoRepository = videogiocoRepository;
            this.mapper = mapper;
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

    }
}
