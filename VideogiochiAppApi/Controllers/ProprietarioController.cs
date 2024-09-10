using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideogiochiAppApi.Dto;
using VideogiochiAppApi.Interfaces;
using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : Controller
    {
        private readonly IProprietarioRepository proprietarioRepository;
        private readonly IMapper mapper;

        public ProprietarioController(IProprietarioRepository proprietarioRepository, IMapper mapper)
        {
            this.proprietarioRepository = proprietarioRepository;
            this.mapper = mapper;
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




    }
}
