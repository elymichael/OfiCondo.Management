namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Fees.Queries.Detail;
    using OfiCondo.Management.Application.Features.Fees.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class FeesUnitTests : BaseController
    {
        private readonly string controllerName = "Fees";
        public FeesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<FeeListVm>>(response);

            Assert.IsType<List<FeeListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.FeeID[0]}");

            var result = JsonConvert.DeserializeObject<FeeDetailVm>(response);

            Assert.IsType<FeeDetailVm>(result);
            Assert.NotNull(result);
        }
    }
}
