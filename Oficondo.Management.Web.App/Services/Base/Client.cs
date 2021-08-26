namespace Oficondo.Management.Web.App.Services.Base
{
    using Oficondo.Management.Web.App.Contracts;
    using System.Net.Http;

    public partial class Client: BaseClient, IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
