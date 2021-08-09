namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Payees.Queries.Detail;
    using OfiCondo.Management.Application.Features.Payees.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class PayeesUnitTests: BaseController
    {
        public PayeesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecEndPoint("/api/payees/all");

            var result = JsonConvert.DeserializeObject<List<PayeeListVm>>(response);

            Assert.IsType<List<PayeeListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecEndPoint($"/api/payees/{ConstantKeyValue.PayeeID}");

            var result = JsonConvert.DeserializeObject<PayeeDetailVm>(response);

            Assert.IsType<PayeeDetailVm>(result);
            Assert.NotNull(result);
        }
    }
}
