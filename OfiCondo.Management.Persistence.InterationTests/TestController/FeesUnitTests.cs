namespace OfiCondo.Management.Persistence.InterationTests
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Api.Controllers;
    using OfiCondo.Management.Application.Features.Fees.Queries.Detail;
    using OfiCondo.Management.Application.Features.Fees.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using OfiCondo.Management.Persistence.InterationTests.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class FeesUnitTests : BaseController
    {
        private readonly string controllerName = "Fees";
        private readonly Mock<IMediator> _mediator;
        public FeesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<FeeListVm>>(response);

            Assert.IsType<List<FeeListVm>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.FeeID[0]}");

            var result = JsonConvert.DeserializeObject<FeeDetailVm>(response);

            Assert.IsType<FeeDetailVm>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultInsert()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new FeesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Create(new Application.Features.Fees.Commands.Create.CreateFeeCommand
            {
                CondominiumId = Guid.NewGuid(),
                Amount = 50,
                DateBegin = DateTime.Now,
                DateEnd = DateTime.Now,
                Name = "Cuenta La Fe"

            });

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultUpdate()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new FeesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Update(new Application.Features.Fees.Commands.Update.UpdateFeeCommand
            {
                FeeId = Guid.NewGuid(),
                CondominiumId = Guid.NewGuid(),
                Amount = 50,
                DateBegin = DateTime.Now,
                DateEnd = DateTime.Now,
                Name = "Cuenta La Fe"

            });

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultDeleteMoq()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new FeesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Delete(Guid.NewGuid());

            Assert.IsType<ActionResult<Guid>>(result);
        }
        
        public async Task ReturnSuccessResultDelete()
        {
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.FeeID}");

            Assert.IsType<Guid>(id);
        }
    }
}
