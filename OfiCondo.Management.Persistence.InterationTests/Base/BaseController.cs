namespace OfiCondo.Management.Persistence.InterationTests.Base
{
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    public class BaseController : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public readonly CustomWebApplicationFactory<Startup> _factory;
        public BaseController(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        public async virtual Task<string> ExecGetEndPoint(string url)
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public async virtual Task<T> ExecPostEndPoint<TParam, T>(string url, TParam value) 
            where TParam: class 
            where T: class
        {            
            var json = JsonConvert.SerializeObject(value);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _factory.GetAnonymousClient();

            var response = await client.PostAsync(url, data);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public async virtual Task<T> ExecPutEndPoint<TParam, T>(string url, TParam value)
            where TParam : class
            where T : class
        {
            var json = JsonConvert.SerializeObject(value);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _factory.GetAnonymousClient();

            var response = await client.PutAsync(url, data);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public async virtual Task<T> ExecDeleteEndPoint<T>(string url)
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.DeleteAsync(url);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseString);            
        }
    }
}
