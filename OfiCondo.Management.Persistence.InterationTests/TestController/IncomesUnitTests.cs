namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Incomes.Queries.Detail;
    using OfiCondo.Management.Application.Features.Incomes.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class IncomesUnitTests : BaseController
    {
        private readonly string controllerName = "Incomes";
        public IncomesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<IncomeListVm>>(response);

            Assert.IsType<List<IncomeListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.IncomeID}");

            var result = JsonConvert.DeserializeObject<IncomeDetailVm>(response);

            Assert.IsType<IncomeDetailVm>(result);
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
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.IncomeID}");

            Assert.IsType<Guid>(id);
        }
    }
}
