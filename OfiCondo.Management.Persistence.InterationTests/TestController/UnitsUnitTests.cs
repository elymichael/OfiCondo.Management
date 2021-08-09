namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Units.Queries.Detail;
    using OfiCondo.Management.Application.Features.Units.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class UnitsUnitTests : BaseController    
    {
        private readonly string controllerName = "Units";
        public UnitsUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<UnitListVm>>(response);

            Assert.IsType<List<UnitListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.UnitID}");

            var result = JsonConvert.DeserializeObject<UnitDetailVm>(response);

            Assert.IsType<UnitDetailVm>(result);
            Assert.NotNull(result);
        }
        [Fact]
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
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.UnitID}");

            Assert.IsType<Guid>(id);
        }
    }
}
