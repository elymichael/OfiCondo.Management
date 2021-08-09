namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Condominia.Queries.Detail;
    using OfiCondo.Management.Application.Features.Condominia.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class CondominiaUnitTests : BaseController
    {
        public CondominiaUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecEndPoint("/api/Condominia/all");

            var result = JsonConvert.DeserializeObject<List<CondominiumListVm>>(response);

            Assert.IsType<List<CondominiumListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecEndPoint($"/api/Condominia/{ConstantKeyValue.CondominiumID}");

            var result = JsonConvert.DeserializeObject<CondominiumDetailVm>(response);

            Assert.IsType<CondominiumDetailVm>(result);
            Assert.NotNull(result);
        }
    }
}
