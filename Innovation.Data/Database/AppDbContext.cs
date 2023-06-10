using Innovation.Data.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Innovation.Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<IdeaAppUserMapping> IdeaAppUserMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdeaAppUserMapping>().HasKey(x => new { x.IdeaId, x.EmployeeId });
            base.OnModelCreating(modelBuilder);
        }
    }
}