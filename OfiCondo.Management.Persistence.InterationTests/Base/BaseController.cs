namespace OfiCondo.Management.Persistence.InterationTests.Base
{
    using OfiCondo.Management.Api;
    using System.Threading.Tasks;
    using Xunit;
    public class BaseController : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public readonly CustomWebApplicationFactory<Startup> _factory;
        public BaseController(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        public async virtual Task<string> ExecEndPoint(string url)
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
    }
}
