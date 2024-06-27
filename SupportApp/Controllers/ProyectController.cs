using SupportApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SupportApp.Migrations;


namespace SupportApp.Proyects
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProyectController : ControllerBase
    {
        private readonly IProyectRepository _proyectRepository;
        private readonly IMapper _mapper;
        public ProyectController(IProyectRepository proyectRepository, IMapper mapper)
        {
            _proyectRepository = proyectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProyectDto>>> GetAllProyects()
        {
            var proyects = await _proyectRepository.GetAllProyects();
            var proyectsDto = _mapper.Map<IEnumerable<Proyects>>(proyects);
            return Ok(proyectsDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProyectDto>> CreateProyect(CreateProyectDto proyectCreate)
        {
            var proyects = _mapper.Map<Proyects>(proyectCreate);
            var proyectsId = await _proyectRepository.CreateProyects(proyects);

            return Ok(proyectsId);
        }
        
        
    }
}