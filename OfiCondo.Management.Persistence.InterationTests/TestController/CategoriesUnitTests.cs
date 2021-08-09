namespace OfiCondo.Management.Persistence.InterationTests
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Application.Features.Categories.Queries.Detail;
    using OfiCondo.Management.Application.Features.Categories.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class CategoriesUnitTests : BaseController
    {
        public CategoriesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }
        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecEndPoint("/api/Categories/all");

            var result = JsonConvert.DeserializeObject<List<CategoryListVm>>(response);

            Assert.IsType<List<CategoryListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecEndPoint($"/api/Categories/{ConstantKeyValue.CategoryID[0]}");

            var result = JsonConvert.DeserializeObject<CategoryDetailVm>(response);

            Assert.IsType<CategoryDetailVm>(result);
            Assert.NotNull(result);
        }
    }
}
