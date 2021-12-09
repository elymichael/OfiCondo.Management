namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Models.Authentication;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;
    public class AccountsUnitTests: BaseController
    {
        private readonly string controllerName = "Account";
        public AccountsUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

        [Fact]
        public async Task TestListAllAccounts()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/All");

            var result = JsonConvert.DeserializeObject<List<AuthorizedUsers>>(response);

            Assert.IsType<List<AuthorizedUsers>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task TestAccountAuthentication()
        {
            var data = new AuthenticationRequest { Email = "elymichael@sitcsrd.com", Password = "administrador" };

            var result = await base.ExecPostEndPoint<AuthenticationRequest, AuthenticationResponse>($"/api/{controllerName}/Authenticate", data);
            
            Assert.IsType<AuthenticationResponse>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestAccountRegistration()
        {
            var data = new RegistrationRequest
            {
                Email = "developer@sitcsrd.com",
                Password = "Developer$01",
                FirstName = "Developer",
                LastName = "Senior",
                Phone = "8099878989",
                UserName = "developer"
            };

            await Assert.ThrowsAsync<HttpRequestException>(async () => await base.ExecPostEndPoint<RegistrationRequest, RegistrationResponse>($"/api/{controllerName}/Register", data));
        }

        [Fact]
        public async Task TestAccountById()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/43961c86-2753-4924-8c1e-abc2df47f077");

            var result = JsonConvert.DeserializeObject<AuthorizedUsers>(response);

            Assert.NotNull(result);
            Assert.IsType<AuthorizedUsers>(result);            
        }
    }
}
