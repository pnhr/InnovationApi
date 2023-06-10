namespace Innovation.UnitTest.Data
{
    public partial class AppRepositoryTests
    {
        [Fact]
        public void GetById_WhenCalledWithAValidId_ReturnsARecordWhichMatchesWithId()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                AppUser emp = repository.GetById<AppUser>(1);

                Assert.Equal("TestOne", emp.FirstName);
            }
        }
        [Fact]
        public void GetById_WhenCalledWithAValidCompositKey_ReturnsARecordWhichMatchesWithCompositKey()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                IdeaAppUserMapping compositKeyTest = repository.GetById<IdeaAppUserMapping>(1, 1);

                Assert.Equal(1, compositKeyTest.IdeaId);
            }
        }
    }
}
