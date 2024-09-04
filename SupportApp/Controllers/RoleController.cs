using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportApp.Data;
using SupportApp.Models;

namespace SupportApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly RoleRepository _roleRepository;

        public RoleController(AppDbContext context, IMapper mapper, RoleRepository roleRepository)
        {
            _context = context;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
    }
}
