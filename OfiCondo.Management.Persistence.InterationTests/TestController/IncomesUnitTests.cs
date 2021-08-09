namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Incomes.Queries.Detail;
    using OfiCondo.Management.Application.Features.Incomes.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class IncomesUnitTests : BaseController
    {
        public IncomesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecEndPoint("/api/Incomes/all");

            var result = JsonConvert.DeserializeObject<List<IncomeListVm>>(response);

            Assert.IsType<List<IncomeListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecEndPoint($"/api/Incomes/{ConstantKeyValue.IncomeID}");

            var result = JsonConvert.DeserializeObject<IncomeDetailVm>(response);

            Assert.IsType<IncomeDetailVm>(result);
            Assert.NotNull(result);
        }
    }
}
