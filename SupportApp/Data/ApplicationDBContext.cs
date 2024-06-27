namespace SupportApp.Data;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Proyects.Proyects> Proyects { get; set; }
    public DbSet<SupportTask> SupportTasks { get; set; }
}