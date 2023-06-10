namespace Innovation.UnitTest.TestHelpers
{
    public class TestDbContext : AppDbContext
    {
        public TestDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdeaAppUserMapping>().HasKey(x => new { x.IdeaId, x.EmployeeId });
            modelBuilder.Seed();
        }
    }
}
