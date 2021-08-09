namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Banks.Queries.Detail;
    using OfiCondo.Management.Application.Features.Banks.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class BanksUnitTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly string controllerName = "Banks";
        private readonly CustomWebApplicationFactory<Startup> _factory;
        public BanksUnitTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync($"/api/{controllerName}/all");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<BankListVm>>(responseString);

            Assert.IsType<List<BankListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync($"/api/{controllerName}/{ConstantKeyValue.BankID}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BankDetailVm>(responseString);

            Assert.IsType<BankDetailVm>(result);
            Assert.NotNull(result);
        }
    }
}
