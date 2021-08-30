using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Oficondo.Management.Web.App.Auth;
using Oficondo.Management.Web.App.Contracts;
using Oficondo.Management.Web.App.Services;
using Oficondo.Management.Web.App.Services.Base;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Oficondo.Management.Web.App
{
    public class Program
    {
        private const string apiUrl = "https://localhost:44312";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri(apiUrl)
            });

            builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri(apiUrl));

            builder.Services.AddScoped<IPaymentMethodDataService, PaymentMethodDataService>();
            builder.Services.AddScoped<IBankDataService, BankDataService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            await builder.Build().RunAsync();
        }
    }
}
