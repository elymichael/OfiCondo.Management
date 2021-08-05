namespace OfiCondo.Management.Persistence.InterationTests
{
    using OfiCondo.Management.Application.Contracts;
    using OfiCondo.Management.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Shouldly;
    using System;
    using Xunit;
    public class OfiCondoDbContextTests
    {
        private readonly OfiCondoDbContext _oficondoDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;
        public OfiCondoDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<OfiCondoDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _loggedInUserId = "00000000-0000-0000-0000-0000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _oficondoDbContext = new OfiCondoDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }
        [Fact]
        public async void TestDbContext()
        {
            var cat = new Category() { CategoryId = Guid.NewGuid(), Name = "NOMINA" };
            _oficondoDbContext.Categories.Add(cat);
            await _oficondoDbContext.SaveChangesAsync();

            cat.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
