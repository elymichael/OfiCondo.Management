namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Models.Authentication;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;
    public class AccountsUnitTests: BaseController
    {
        public AccountsUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

        [Fact]
        public async Task TestListAllAccounts()
        {
            string response = await base.ExecEndPoint("/api/Account/All");

            var result = JsonConvert.DeserializeObject<List<AuthorizedUsers>>(response);

            Assert.IsType<List<AuthorizedUsers>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestAccountAuthentication()
        {

        }

        [Fact]
        public void TestAccountRegistration()
        {

        }
    }
}
