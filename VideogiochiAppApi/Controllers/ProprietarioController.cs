using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideogiochiAppApi.Dto;
using VideogiochiAppApi.Interfaces;
using VideogiochiAppApi.Model;
using VideogiochiAppApi.Repository;

namespace VideogiochiAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : Controller
    {
        private readonly IPaeseRepository paeseRepository;
        private readonly IProprietarioRepository proprietarioRepository;
        private readonly IMapper mapper;

        public ProprietarioController(IProprietarioRepository proprietarioRepository, IMapper mapper, IPaeseRepository paeseRepository)
        {
            this.proprietarioRepository = proprietarioRepository;
            this.mapper = mapper;
            this.paeseRepository = paeseRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProprietarioDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProprietari()
        {
            var proprie = proprietarioRepository.GetProprietari();
            var proprieDto = mapper.Map<IEnumerable<ProprietarioDto>>(proprie);
            if (proprieDto == null)
            {
                return NotFound();
            }
            return Ok(proprieDto);
        }
        [HttpGet("id/{id}")]
        [ProducesResponseType(200, Type = typeof(ProprietarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GeteProprietario(int id)
        {
            var proprie = proprietarioRepository.GetProprietario(id);
            var proprieDto = mapper.Map<ProprietarioDto>(proprie);
            if (proprieDto == null)
            {
                return NotFound();
            }
            return Ok(proprieDto);
        }
        [HttpGet("name/{name}")]
        [ProducesResponseType(200, Type = typeof(ProprietarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GeteProprietarioByNome(string name)
        {
            var proprie = proprietarioRepository.GetNome(name);
            var proprieDto = mapper.Map<ProprietarioDto>(proprie);
            if (proprieDto == null)
            {
                return NotFound();
            }
            return Ok(proprieDto);
        }
        [HttpGet("{propId}/byGioco")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VideogiocoDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetGiocoByProprietario(int propId)
        {
            var proprie = proprietarioRepository.GetVideogiocoByOwner(propId);
            var proprieDto = mapper.Map<IEnumerable<VideogiocoDto>>(proprie);
            if (proprieDto == null)
            {
                return NotFound();
            }
            return Ok(proprieDto);
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ProprietarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateProprietario([FromQuery] int paeseId,[FromBody] ProprietarioDto proprietarioCreazione)
        {

            if (proprietarioCreazione == null)
            {
                return BadRequest("I dati forniti non sono validi.");
            }
            var proprietario = mapper.Map<Proprietario>(proprietarioCreazione);

            proprietario.Paese = paeseRepository.GetPaese(paeseId);

            if (!proprietarioRepository.CreateProprietario(proprietario))
            {
                ModelState.AddModelError("", "Qualcosa è andato storto durante la creazione del proprietario.");
                return StatusCode(500, ModelState);
            }
            return CreatedAtAction(nameof(GetProprietari), new { id = proprietario.IdProprietario }, proprietarioCreazione);
        }
        [HttpPut("{proprietarioId}")]
        [ProducesResponseType(200, Type = typeof(ProprietarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Updateproprietario(int proprietarioId, [FromBody] ProprietarioDto updateProprietario)
        {
            if (updateProprietario == null)
            {
                return BadRequest("Dati forniti non correttamente");
            }
            if (proprietarioId != updateProprietario.IdProprietario)
            {
                return BadRequest("Non coincide");
            }
            var proprietarioMap = mapper.Map<Proprietario>(updateProprietario);

            if (!proprietarioRepository.UpdateProprietario(proprietarioMap))
            {
                return StatusCode(500);
            }
            return NoContent();
        }
        [HttpDelete("{proprietarioId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProprietario(int proprietarioId)
        {

            var proprietarioToDelete = proprietarioRepository.GetProprietario(proprietarioId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!proprietarioRepository.DeleteProprietario(proprietarioToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }





    }
}
