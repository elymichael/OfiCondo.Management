namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Expenses.Queries.Detail;
    using OfiCondo.Management.Application.Features.Expenses.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class ExpensesUnitTests : BaseController
    {
        public ExpensesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecEndPoint("/api/Expenses/all");

            var result = JsonConvert.DeserializeObject<List<ExpenseListVm>>(response);

            Assert.IsType<List<ExpenseListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecEndPoint($"/api/Expenses/{ConstantKeyValue.ExpenseID}");

            var result = JsonConvert.DeserializeObject<ExpenseDetailVm>(response);

            Assert.IsType<ExpenseDetailVm>(result);
            Assert.NotNull(result);
        }
    }
}
