using SupportApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FluentValidation;
using SupportApp.DTOs;


namespace SupportApp.Proyects
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProyectController : ControllerBase
    {
        private readonly IProyectRepository _proyectRepository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private IValidator<CreateProyectDto> _validator;
        public ProyectController( AppDbContext context,IProyectRepository proyectRepository, IMapper mapper, IValidator<CreateProyectDto> createValidator)
        {
            _proyectRepository = proyectRepository;
            _mapper = mapper;
            _validator = createValidator;
            _context = context;
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
            var validatorResult = await _validator.ValidateAsync(proyectCreate);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }
            var proyects = _mapper.Map<Proyects>(proyectCreate);
            var proyectsId = await _proyectRepository.CreateProyects(proyects);

            return Ok(proyectsId);
        }
        
    }
}