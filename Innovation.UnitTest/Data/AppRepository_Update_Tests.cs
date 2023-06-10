namespace Innovation.UnitTest.Data
{
    public partial class AppRepositoryTests
    {
        [Fact]
        public void Update_WhenCalledWithOneObject_ReturnsNothingButDataWillbeUpdatedInDb()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppUser emp = new AppUser { EmployeeId = 1, UserId = "CORP\\e999999", FirstName = "TestUpdated", LastName = "Updated", DateUpdated = DateTime.Now };

                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                repository.Update(emp);

                AppUser empTest = repository.GetById<AppUser>(1);

                Assert.Equal("TestUpdated", empTest.FirstName);
            }
        }

        [Fact]
        public async Task UpdateAsync_WhenCalledWithOneObject_ReturnsNothingButDataWillbeUpdatedInDb()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppUser emp = new AppUser { EmployeeId = 1, UserId = "CORP\\e999999", FirstName = "TestUpdatedAsync", LastName = "Updated", DateUpdated = DateTime.Now };

                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                await repository.UpdateAsync(emp);

                AppUser empTest = repository.GetById<AppUser>(1);

                Assert.Equal("TestUpdatedAsync", empTest.FirstName);
            }
        }
    }
}
