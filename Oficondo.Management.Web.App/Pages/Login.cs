namespace Oficondo.Management.Web.App.Pages
{
    using Microsoft.AspNetCore.Components;
    using Oficondo.Management.Web.App.Contracts;
    using Oficondo.Management.Web.App.ViewModels;
    public partial class Login
    {
        public LoginViewModel LoginViewModel { get;set;}
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }
        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Login() { }

        protected override void OnInitialized()
        {
            LoginViewModel = new LoginViewModel();
        }

        protected async void HandleValidSubmit()
        {
            if(await AuthenticationService.Authenticate(LoginViewModel.Email, LoginViewModel.Password))
            {
                NavigationManager.NavigateTo("Home");
            }
            Message = "Username/password combination unkown";
        }
    }
}
