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

        public SupportTaskController(ISupportTaskRepository supportTaskRepository, IMapper mapper)
        {
            _supportTaskRepository = supportTaskRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<SupportTaskDto>>> GetAllSupportTasks()
        {
            var supportTasks = await _supportTaskRepository.GetAllSupportTasks();
            var supportTask = _mapper.Map<List<SupportTask>>(supportTasks);
        
            return Ok(supportTasks);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateSupportTask(SupportTaskDto supportTaskToCreate, int proyectId)
        {
            var supportTask = _mapper.Map<SupportTask>(supportTaskToCreate);
            supportTask.ProyectId = proyectId;
            var supportTaskId = await _supportTaskRepository.CreateSupportTask(supportTask);
        
            return Ok(supportTaskId);
        }
    }
}
