namespace Oficondo.Management.Web.App.Services.Base
{
    using Blazored.LocalStorage;
    using Oficondo.Management.Web.App.Constants;
    using Oficondo.Management.Web.App.Contracts;
    using Oficondo.Management.Web.App.Model.Base;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class BaseDataService
    {
        protected readonly ILocalStorageService _localStorageService;
        protected IClient _client;
        public BaseDataService(IClient client, ILocalStorageService localStorage)
        {
            _localStorageService = localStorage;
            _client = client;
        }

        protected ApiResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if(ex.StatusCode == 400)
            {
                return new ApiResponse<Guid>() { Message = "Validation errors have ocurred", ValidationErrors = ex.Response, Success = false };
            }
            else if(ex.StatusCode == 404)
            {
                return new ApiResponse<Guid>() { Message = "The requested item could not be found", Success = false };
            }
            else
            {
                return new ApiResponse<Guid>() { Message = "Something went wrong", Success = false };
            }
        }

        public async Task AddBearerToken()
        {
            if (await _localStorageService.ContainKeyAsync(AppConstants.TokenName))
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AppConstants.BearerName, await _localStorageService.GetItemAsync<string>(AppConstants.TokenName));
        }
    }
}
