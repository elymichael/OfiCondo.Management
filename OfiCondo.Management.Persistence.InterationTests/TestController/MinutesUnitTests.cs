namespace OfiCondo.Management.Persistence.InterationTests
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Api.Controllers;
    using OfiCondo.Management.Application.Features.Minutes.Queries.Detail;
    using OfiCondo.Management.Application.Features.Minutes.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using OfiCondo.Management.Persistence.InterationTests.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class MinutesUnitTests : BaseController
    {
        private readonly string controllerName = "Minutes";
        private readonly Mock<IMediator> _mediator;
        public MinutesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<MinuteListVm>>(response);

            Assert.IsType<List<MinuteListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.MinuteID}");

            var result = JsonConvert.DeserializeObject<MinuteDetailVm>(response);

            Assert.IsType<MinuteDetailVm>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultInsert()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new MinutesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Create(new Application.Features.Minutes.Commands.Create.CreateMinuteCommand
            {
                Description = "Cuenta de Ahorro Edificio Banco La Fe",                
                CondominiumId = Guid.NewGuid(),
                RecordDate = DateTime.Now

            });

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultUpdate()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new MinutesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Update(new Application.Features.Minutes.Commands.Update.UpdateMinuteCommand
            {
                Description = "Cuenta de Ahorro Edificio Banco La Fe",
                CondominiumId = Guid.NewGuid(),
                RecordDate = DateTime.Now

            }); ;

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultDeleteMoq()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new MinutesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Delete(Guid.NewGuid());

            Assert.IsType<ActionResult<Guid>>(result);
        }

        public async Task ReturnSuccessResultDelete()
        {
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.MinuteID}");

            Assert.IsType<Guid>(id);
        }
    }
}
