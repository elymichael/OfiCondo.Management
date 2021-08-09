namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Minutes.Queries.Detail;
    using OfiCondo.Management.Application.Features.Minutes.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class MinutesUnitTests : BaseController
    {
        public MinutesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecEndPoint("/api/Minutes/all");

            var result = JsonConvert.DeserializeObject<List<MinuteListVm>>(response);

            Assert.IsType<List<MinuteListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecEndPoint($"/api/Minutes/{ConstantKeyValue.MinuteID}");

            var result = JsonConvert.DeserializeObject<MinuteDetailVm>(response);

            Assert.IsType<MinuteDetailVm>(result);
            Assert.NotNull(result);
        }
    }
}
