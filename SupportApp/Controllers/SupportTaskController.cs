using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportApp.Data;
using SupportApp.Proyects;
using SupportTask.Repository;

namespace SupportApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SupportTaskController : ControllerBase
    {
        private readonly ISupportTaskRepository _supportTaskRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private static readonly string container="supportTasks";

        public SupportTaskController(AppDbContext context,ISupportTaskRepository supportTaskRepository, IMapper mapper)
        {
            _supportTaskRepository = supportTaskRepository;
            _context = context;
            _mapper = mapper;
            
        }
        
        
        [HttpGet]
        public async Task<ActionResult<List<SupportTaskDto>>> GetAllProyects()
        {
            var supportTasks = await _supportTaskRepository.GetAllSupportTasks();
            var supportTasksDtos = _mapper.Map<List<SupportTask>>(supportTasks);
            return Ok(supportTasks);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<SupportTaskDto>>> GetIdTask(int id)
        {
            var task = await _supportTaskRepository.ExistTask(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupportTask(CreateSupportTaskDto taskDto)
        {
            var supportTask = _mapper.Map<Task>(taskDto);
            await _supportTaskRepository.CreateSupportTask(null);
            return Ok(supportTask);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id,[FromBody]CreateSupportTaskDto taskDto)
        {
            var supportTask = await _context.SupportTasks.FindAsync(id);
            if (supportTask == null)
            {
                return NotFound();
            }

            _mapper.Map(taskDto, supportTask);
            await _supportTaskRepository.UpdateTask(supportTask);
            return Ok(supportTask);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var task = await _context.SupportTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            await _supportTaskRepository.DeleteTask(task.Id);
            return NoContent();
        }
    }
}
