using SupportApp.Data;
using SupportApp;
using Microsoft.EntityFrameworkCore;

namespace SupportTask.Repository;

public class SupportTaskRepository : ISupportTaskRepository
{
    private readonly AppDbContext _context;

    public SupportTaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SupportApp.SupportTask>> GetAllSupportTasks()
    {
        return await _context.SupportTasks.AsNoTracking().ToListAsync();
    }
    

    public async Task<int> CreateSupportTask( SupportApp.SupportTask supportTask )
    {
        _context.Add( supportTask );
        await _context.SaveChangesAsync();

        return supportTask.Id;
    }
}