namespace Innovation.UnitTest.TestHelpers
{
    public static class DBDataSets
    {
        public static List<AppUser> GetEmployeeTableTestData()
        {
            List<AppUser> employees = new List<AppUser>();
            employees.Add(new AppUser { EmployeeId = 1, UserId = "CORP\\e999999", FirstName = "TestOne", LastName = "One", Email = "test@test.com", IsActive = true, DateUpdated = DateTime.Now });
            employees.Add(new AppUser { EmployeeId = 2, UserId = "CORP\\e777777", FirstName = "TestTwo", LastName = "Two", Email = "test@test.com", IsActive = true, DateUpdated = DateTime.Now });
            employees.Add(new AppUser { EmployeeId = 3, UserId = "CORP\\e666666", FirstName = "TestThree", LastName = "Three", Email = "test@test.com", IsActive = true, DateUpdated = DateTime.Now });
            employees.Add(new AppUser { EmployeeId = 4, UserId = "CORP\\e555555", FirstName = "TestFour", LastName = "Four", Email = "test@test.com", IsActive = true, DateUpdated = DateTime.Now });
            return employees;
        }

        public static List<Idea> GetIdeasTestData()
        {
            List<Idea> data = new List<Idea>();
            data.Add(new Idea { Id = 1, IdeaRef = "AUT1", IdeaName = "Automation Test one", IdeaDescription = "Test one desc", IsActive = true, DateUpdated = DateTime.Now, UpdatedBy = "unittest" });
            data.Add(new Idea { Id = 2, IdeaRef = "AUT2", IdeaName = "Automation Test Two", IdeaDescription = "Test one desc", IsActive = true, DateUpdated = DateTime.Now, UpdatedBy = "unittest" });
            data.Add(new Idea { Id = 3, IdeaRef = "SIM3", IdeaName = "Simplify Room Test one", IdeaDescription = "Test one desc", IsActive = true, DateUpdated = DateTime.Now, UpdatedBy = "unittest" });
            data.Add(new Idea { Id = 4, IdeaRef = "SIM4", IdeaName = "Simplify Room Test Two", IdeaDescription = "Test one desc", IsActive = true, DateUpdated = DateTime.Now, UpdatedBy = "unittest" });
            return data;
        }

        public static List<IdeaAppUserMapping> GetIdeaAppUserMappingTestData()
        {
            List<IdeaAppUserMapping> data = new List<IdeaAppUserMapping>();
            data.Add(new IdeaAppUserMapping { IdeaId = 1, EmployeeId = 1, IsActive = true, DateUpdated = DateTime.Now, UpdatedBy = "unittest" });
            data.Add(new IdeaAppUserMapping { IdeaId = 2, EmployeeId = 2, IsActive = true, DateUpdated = DateTime.Now, UpdatedBy = "unittest" });

            data.Add(new IdeaAppUserMapping { IdeaId = 3, EmployeeId = 3, IsActive = true, DateUpdated = DateTime.Now, UpdatedBy = "unittest" });
            data.Add(new IdeaAppUserMapping { IdeaId = 4, EmployeeId = 4, IsActive = true, DateUpdated = DateTime.Now, UpdatedBy = "unittest" });

            return data;
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasData(GetEmployeeTableTestData());
            modelBuilder.Entity<Idea>().HasData(GetIdeasTestData());
            modelBuilder.Entity<IdeaAppUserMapping>().HasData(GetIdeaAppUserMappingTestData());
        }
    }
}
