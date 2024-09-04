using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupportApp.Data;
using SupportApp.Models;
using SupportApp.Proyects;

namespace SupportApp.Repository;



public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository( AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUser()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<string> CreateUser(User userDto)
    {
        _context.Add(userDto);
        await _context.SaveChangesAsync();
        return userDto.FirstName;
    }

    public async Task UpdateUser(User user)
    {
        _context.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
    }
    
}