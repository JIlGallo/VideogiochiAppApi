using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using VideogiochiAppApi.Dto;
using VideogiochiAppApi.Interfaces;
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
            if(paeseMap == null)
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


    }
}
