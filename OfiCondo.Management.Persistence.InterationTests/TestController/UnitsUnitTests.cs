namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Units.Queries.Detail;
    using OfiCondo.Management.Application.Features.Units.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class UnitsUnitTests : BaseController    
    {
        public UnitsUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecEndPoint("/api/Units/all");

            var result = JsonConvert.DeserializeObject<List<UnitListVm>>(response);

            Assert.IsType<List<UnitListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecEndPoint($"/api/Units/{ConstantKeyValue.UnitID}");

            var result = JsonConvert.DeserializeObject<UnitDetailVm>(response);

            Assert.IsType<UnitDetailVm>(result);
            Assert.NotNull(result);
        }
    }
}
