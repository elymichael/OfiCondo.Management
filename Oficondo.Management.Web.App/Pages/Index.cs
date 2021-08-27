namespace Oficondo.Management.Web.App.Pages
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Oficondo.Management.Web.App.Auth;
    using Oficondo.Management.Web.App.Contracts;
    using System.Threading.Tasks;

    public partial class Index
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        }

        protected void NavigateToLogin()
        {
            NavigationManager.NavigateTo("Login");
        }
        protected void NavigateToRegister()
        {
            NavigationManager.NavigateTo("Register");
        }
        protected async void Logout()
        {
            await AuthenticationService.Logout();
        }
    }
}
