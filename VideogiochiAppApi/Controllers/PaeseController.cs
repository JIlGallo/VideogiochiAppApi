using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using VideogiochiAppApi.Dto;
using VideogiochiAppApi.Interfaces;
using VideogiochiAppApi.Model;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace VideogiochiAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaeseController : Controller
    {
        private readonly IPaeseRepository paeseRepository;
        private readonly IMapper mapper;

        public PaeseController(IPaeseRepository paeseRepository, IMapper mapper)
        {
            this.paeseRepository = paeseRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PaeseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPaesi()
        {
            var paesi = paeseRepository.GetPaesi();
            var paeseMap = mapper.Map<IEnumerable<PaeseDto>>(paesi);
            if (paeseMap == null)
            {
                return NotFound();
            }
            return Ok(paeseMap);
        }
        [HttpGet("id/{id}")]
        [ProducesResponseType(200, Type = typeof(PaeseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPaesi(int id)
        {
            var paesi = paeseRepository.GetPaese(id);
            var paeseMap = mapper.Map<PaeseDto>(paesi);
            if (paeseMap == null)
            {
                return NotFound();
            }
            return Ok(paeseMap);
        }
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(200, Type = typeof(PaeseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPaesiNome(string nome)
        {
            var paesi = paeseRepository.GetNome(nome);
            var paeseMap = mapper.Map<PaeseDto>(paesi);
            if (paeseMap == null)
            {
                return NotFound();
            }
            return Ok(paeseMap);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(PaeseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreatePaese([FromBody] PaeseDto creazionePaese)
        {

            if (creazionePaese == null)
            {
                return BadRequest("I dati forniti non sono validi.");
            }

            var paese = paeseRepository.GetPaesi().FirstOrDefault(p => p.Name.Trim().ToUpper() == creazionePaese.Name.TrimEnd());

            if (paese != null)
            {
                return Conflict("Il paese esiste già.");
            }
            var paeseMap = mapper.Map<Paese>(creazionePaese);
            var isCreato = paeseRepository.CreatePaese(paeseMap);
            if (!isCreato)
            {
                return StatusCode(500, "Qualcosa è andato storto durante il salvataggio del paese.");
            }
            return Ok("Creato con successo");
        }
        [HttpPut("{paeseId}")]
        [ProducesResponseType(200, Type = typeof(PaeseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePaese(int paeseId, [FromBody] PaeseDto updatePaese)
        {
            if(updatePaese == null)
            {
                return BadRequest("Dati forniti non correttamente");
            }
            if (paeseId != updatePaese.IdPaese)
            {
                return BadRequest("Non coincide");
            }
            var paeseMap = mapper.Map<Paese>(updatePaese);

            if (!paeseRepository.UpdatePaese(paeseMap))
            {
                return StatusCode(500);
            }
            return NoContent();
        }
        [HttpDelete("{paeseId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCountry(int paeseId)
        {

            var countryToDelete = paeseRepository.GetPaese(paeseId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!paeseRepository.DeletePaese(countryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
