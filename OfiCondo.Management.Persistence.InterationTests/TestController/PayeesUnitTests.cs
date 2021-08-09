namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Payees.Queries.Detail;
    using OfiCondo.Management.Application.Features.Payees.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class PayeesUnitTests: BaseController
    {
        private readonly string controllerName = "payees";
        public PayeesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<PayeeListVm>>(response);

            Assert.IsType<List<PayeeListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.PayeeID}");

            var result = JsonConvert.DeserializeObject<PayeeDetailVm>(response);

            Assert.IsType<PayeeDetailVm>(result);
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
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.PayeeID}");

            Assert.IsType<Guid>(id);
        }
    }
}
