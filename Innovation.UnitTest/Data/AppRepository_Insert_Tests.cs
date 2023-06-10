namespace Innovation.UnitTest.Data
{
    public partial class AppRepositoryTests
    {
        [Fact]
        public void Insert_WhenCalledWithOneObject_ReturnsInsertedRecordWithAutogenaratedPrimaryKeyValue()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppUser emp = new AppUser { UserId = "CORP\\e888888", FirstName = "NewTest", LastName = "Test", DateUpdated = DateTime.Now };

                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                AppUser result = repository.Insert(emp);

                Assert.Equal(4, result.EmployeeId);
            }
        }
        [Fact]
        public void Insert_WhenCalledWithListOfObjects_ReturnsInsertedRecordWithAutogenaratedPrimaryKeyValue()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                List<AppUser> empList = new List<AppUser>
                {
                    new AppUser { UserId = "CORP\\e888888", FirstName = "NewTest", LastName = "One", DateUpdated = DateTime.Now },
                    new AppUser { UserId = "CORP\\e777777", FirstName = "NewTest", LastName = "Two", DateUpdated = DateTime.Now }
                };

                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                List<AppUser> result = repository.Insert(empList);

                Assert.Equal(4, result[0].EmployeeId);
                Assert.Equal(5, result[1].EmployeeId);
            }
        }

        [Fact]
        public async Task InsertAsync_WhenCalledWithOneObject_ReturnsInsertedRecordWithAutogenaratedPrimaryKeyValue()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppUser emp = new AppUser { UserId = "CORP\\e888888", FirstName = "NewTest", LastName = "Test", DateUpdated = DateTime.Now };

                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                AppUser result = await repository.InsertAsync(emp);

                Assert.Equal(4, result.EmployeeId);
            }
        }
        [Fact]
        public async Task InsertAsync_WhenCalledWithListOfObjects_ReturnsInsertedRecordWithAutogenaratedPrimaryKeyValue()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                List<AppUser> empList = new List<AppUser>
                {
                    new AppUser { UserId = "CORP\\e888888", FirstName = "NewTest", LastName = "One", DateUpdated = DateTime.Now },
                    new AppUser { UserId = "CORP\\e777777", FirstName = "NewTest", LastName = "Two", DateUpdated = DateTime.Now }
                };

                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                List<AppUser> result = await repository.InsertAsync(empList);

                Assert.Equal(4, result[0].EmployeeId);
                Assert.Equal(5, result[1].EmployeeId);
            }
        }
    }
}
