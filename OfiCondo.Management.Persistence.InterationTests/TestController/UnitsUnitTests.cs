namespace OfiCondo.Management.Persistence.InterationTests
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Api.Controllers;
    using OfiCondo.Management.Application.Features.Units.Queries.Detail;
    using OfiCondo.Management.Application.Features.Units.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using OfiCondo.Management.Persistence.InterationTests.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class UnitsUnitTests : BaseController    
    {
        private readonly string controllerName = "Units";
        private readonly Mock<IMediator> _mediator;
        public UnitsUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<UnitListVm>>(response);

            Assert.IsType<List<UnitListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.UnitID}");

            var result = JsonConvert.DeserializeObject<UnitDetailVm>(response);

            Assert.IsType<UnitDetailVm>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultInsert()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new UnitsController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Create(new Application.Features.Units.Commands.Create.CreateUnitCommand
            {                
                CondominiumId = Guid.NewGuid(),
                Name = "Apto 3A"                

            });

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultUpdate()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new UnitsController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Update(new Application.Features.Units.Commands.Update.UpdateUnitCommand
            {
                UnitId = Guid.NewGuid(),
                CondominiumId = Guid.NewGuid(),
                Name = "Apto 3A",
                OwnerId = Guid.NewGuid()

            });

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultDeleteMoq()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new UnitsController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Delete(Guid.NewGuid());

            Assert.IsType<ActionResult<Guid>>(result);
        }

        public async Task ReturnSuccessResultDelete()
        {
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.UnitID}");

            Assert.IsType<Guid>(id);
        }
    }
}
