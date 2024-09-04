using SupportApp.Data;
using Microsoft.EntityFrameworkCore;

namespace SupportTask.Repository
{
    public class SupportTaskRepository : ISupportTaskRepository
    {
        private readonly AppDbContext _context;

        public SupportTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupportApp.SupportTask>> GetAllSupportTasks()
        {
            return await _context.SupportTasks.ToListAsync();
        }
        
        public async Task<int> CreateSupportTask(SupportApp.SupportTask supportTaskDto)
        {
            _context.SupportTasks.Add(supportTaskDto);
            await _context.SaveChangesAsync();

            return supportTaskDto.Id;
        }

        public async Task UpdateTask(SupportApp.SupportTask updateSupportTask)
        {
            _context.SupportTasks.Update(updateSupportTask);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistTask(int id)
        {
            return await _context.SupportTasks.AnyAsync(x => x.Id == id);
        }

        public async Task DeleteTask(int id)
        {
            var task = await _context.SupportTasks.FindAsync(id);
            if (task != null)
            {
                _context.SupportTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}