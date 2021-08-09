namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Messages.Queries.Detail;
    using OfiCondo.Management.Application.Features.Messages.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class MessagesUnitTests: BaseController
    {
        public MessagesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecEndPoint("/api/Messages/all");

            var result = JsonConvert.DeserializeObject<List<MessageListVm>>(response);

            Assert.IsType<List<MessageListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecEndPoint($"/api/Messages/{ConstantKeyValue.MessageID}");

            var result = JsonConvert.DeserializeObject<MessageDetailVm>(response);

            Assert.IsType<MessageDetailVm>(result);
            Assert.NotNull(result);
        }
    }
}
