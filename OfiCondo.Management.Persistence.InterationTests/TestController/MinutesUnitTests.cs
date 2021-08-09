namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Minutes.Queries.Detail;
    using OfiCondo.Management.Application.Features.Minutes.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class MinutesUnitTests : BaseController
    {
        private readonly string controllerName = "Minutes";
        public MinutesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<MinuteListVm>>(response);

            Assert.IsType<List<MinuteListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.MinuteID}");

            var result = JsonConvert.DeserializeObject<MinuteDetailVm>(response);

            Assert.IsType<MinuteDetailVm>(result);
            Assert.NotNull(result);
        }
        public async Task ReturnSuccessResultInsert()
        {
            object result = null;

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ReturnSuccessResultUpdate()
        {
            object result = null;

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ReturnSuccessResultDelete()
        {
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.MinuteID}");

            Assert.IsType<Guid>(id);
        }
    }
}
