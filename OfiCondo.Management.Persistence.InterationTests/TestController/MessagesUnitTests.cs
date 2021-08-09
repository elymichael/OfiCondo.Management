namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Messages.Queries.Detail;
    using OfiCondo.Management.Application.Features.Messages.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class MessagesUnitTests: BaseController
    {
        private readonly string controllerName = "Messages";
        public MessagesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<MessageListVm>>(response);

            Assert.IsType<List<MessageListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.MessageID}");

            var result = JsonConvert.DeserializeObject<MessageDetailVm>(response);

            Assert.IsType<MessageDetailVm>(result);
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
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.MessageID}");

            Assert.IsType<Guid>(id);
        }
    }
}
