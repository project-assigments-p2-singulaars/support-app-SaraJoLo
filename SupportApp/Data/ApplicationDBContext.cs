using Microsoft.EntityFrameworkCore;
using SupportApp.Proyects;
using SupportApp.Models;
using IdentityDbContext = Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext;
using SupportApp.relationTable;

namespace SupportApp.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Proyects.Proyects> Proyect { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SupportTask> SupportTasks { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<ProyectUserRole> ProyectUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProyectUserRole>()
                .HasKey(item => new { item.Proyects, item.UserId, item.RoleId });

            modelBuilder.Entity<ProyectUserRole>()
                .HasOne(item => item.Proyects)
                .WithMany(x => x.ProyectUserRoles)
                .HasForeignKey(x => x.Proyects);

            modelBuilder.Entity<ProyectUserRole>()
                .HasOne(item => item.User)
                .WithMany(x => x.ProyectUserRoles)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ProyectUserRole>()
                .HasOne(item => item.Roles)
                .WithMany(x => x.ProyectUserRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<SupportTask>()
                .HasOne(item => item.Proyects)
                .WithMany(x => x.SupportTask)
                .HasForeignKey(x => x.ProyectId);

            modelBuilder.Entity<SupportTask>()
                .HasOne(item => item.User)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.UserId);

        }
    }
}
