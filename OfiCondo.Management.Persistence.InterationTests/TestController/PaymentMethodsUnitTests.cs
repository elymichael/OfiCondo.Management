namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.PaymentMethod.Queries.Detail;
    using OfiCondo.Management.Application.Features.PaymentMethod.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class PaymentMethodsUnitTests : BaseController
    {
        private readonly string controllerName = "PaymentMethods";
        public PaymentMethodsUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<PaymentMethodListVm>>(response);

            Assert.IsType<List<PaymentMethodListVm>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/1");

            var result = JsonConvert.DeserializeObject<PaymentMethodDetailVm>(response);

            Assert.IsType<PaymentMethodDetailVm>(result);
            Assert.NotNull(result);
        }
    }
}
