namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Condominia.Queries.Detail;
    using OfiCondo.Management.Application.Features.Condominia.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class CondominiaUnitTests : BaseController
    {
        private readonly string controllerName = "Condominia";
        public CondominiaUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<CondominiumListVm>>(response);

            Assert.IsType<List<CondominiumListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.CondominiumID}");

            var result = JsonConvert.DeserializeObject<CondominiumDetailVm>(response);

            Assert.IsType<CondominiumDetailVm>(result);
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
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.CondominiumID}");

            Assert.IsType<Guid>(id);
        }
    }
}
