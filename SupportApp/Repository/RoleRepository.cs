using Microsoft.EntityFrameworkCore;
using SupportApp.Data;

namespace SupportApp.Models;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Roles>> GetAllRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Roles> CreateProject(Roles roleDto)
    {
        _context.Add(roleDto);
        await _context.SaveChangesAsync();
        return roleDto;
    }

    public async Task<bool> ExistRole(int id)
    {
        return await _context.Roles.AnyAsync(x => x.Id == id);
    }

    public async Task UpdateProject(Roles role)
    {
        _context.Update(role);
        await _context.SaveChangesAsync();
    }
}