using SupportApp.Data;
using Microsoft.EntityFrameworkCore;

namespace SupportApp.Proyects;

public class ProyectRepository : IProyectRepository

{
    private readonly AppDbContext _context;

    public ProyectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Proyects>> GetAllProyects()
    {
        return await _context.Proyects.ToListAsync();
    }

    public async Task<int> CreateProyects(Proyects proyectsDto)
    {
        _context.Add(proyectsDto);
        await _context.SaveChangesAsync();
        return proyectsDto.Id;
    }

    public async Task UpdateProyect(Proyects proyects)
    {
        _context.Update(proyects);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> ExistProyects(int id)
    {
        return await _context.Proyects.AnyAsync(x=>x.Id == id);
    }

    public async Task Delete(int id)
    {
        await _context.Proyects.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

}