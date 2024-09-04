using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportApp.Data;
using SupportApp.Models;
using SupportApp.Proyects;
using SupportApp.Repository;
using SupportTask.Repository;

namespace SupportApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UserController(AppDbContext context, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            var user = await _userRepository.GetAllUser();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.CreateUser(user);
            return Ok(user);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] CreateUserDto user)
        {
            var modifiedUser = await _context.User.FindAsync(id);
            if (modifiedUser == null)
            {
                return NotFound();
            }

            _mapper.Map(user, modifiedUser);
            await _userRepository.UpdateUser(modifiedUser);
            return Ok(modifiedUser);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var deletedUser = await _context.User.FindAsync(id);
            if (deletedUser == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
