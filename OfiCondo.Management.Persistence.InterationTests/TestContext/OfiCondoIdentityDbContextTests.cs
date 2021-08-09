namespace OfiCondo.Management.Persistence.InterationTests
{
    using Microsoft.EntityFrameworkCore; 
    using Shouldly;
    using System;
    using Xunit;
    using OfiCondo.Management.Identity;

    public class OfiCondoIdentityDbContextTests
    {
        private readonly OfiCondoIdentityDbContext _ofiCondoIdentityDbContext;        
        public OfiCondoIdentityDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<OfiCondoIdentityDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            
            _ofiCondoIdentityDbContext = new OfiCondoIdentityDbContext(dbContextOptions);
        }
        [Fact]
        public async void TestDbContext()
        {
            var data = _ofiCondoIdentityDbContext.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole 
            { 
                Id = Guid.NewGuid().ToString(), 
                Name = "Admin", 
                NormalizedName = "ADMIN" 
            });
                        
            await _ofiCondoIdentityDbContext.SaveChangesAsync();

            data.State.ToString().ShouldBe("Unchanged");
        }
    }
}
