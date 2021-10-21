namespace OfiCondo.Management.Persistence.InterationTests
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Api.Controllers;
    using OfiCondo.Management.Application.Features.Categories.Queries.Detail;
    using OfiCondo.Management.Application.Features.Categories.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using OfiCondo.Management.Persistence.InterationTests.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class CategoriesUnitTests : BaseController
    {
        private readonly string controllerName = "Categories";
        private readonly Mock<IMediator> _mediator;
        public CategoriesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<CategoryListVm>>(response);

            Assert.IsType<List<CategoryListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.CategoryID[0]}");

            var result = JsonConvert.DeserializeObject<CategoryDetailVm>(response);

            Assert.IsType<CategoryDetailVm>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultInsert()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new CategoriesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Create(new Application.Features.Categories.Commands.Create.CreateCategoryCommand
            {                
                AccountId = Guid.NewGuid(),
                Name = "NOMINA"

            });

            Assert.NotNull(result);

        }

        [Fact]
        public async Task ReturnSuccessResultUpdate()
        {
            
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new CategoriesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Update(new Application.Features.Categories.Commands.Update.UpdateCategoryCommand
            {
                CategoryId = Guid.NewGuid(),
                AccountId = Guid.NewGuid(),
                Name = "NOMINA"

            });

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultDeleteMoq()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new CategoriesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Delete(Guid.NewGuid());

            Assert.IsType<ActionResult<Guid>>(result);
        }
        
        public async Task ReturnSuccessResultDelete()
        {
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.CategoryID}");

            Assert.IsType<Guid>(id);
        }
    }
}
