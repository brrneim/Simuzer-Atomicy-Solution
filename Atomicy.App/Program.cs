using AutoMapper;
using Blazored.LocalStorage;
using Atomicy.App.Auth;
using Atomicy.App.Contracts;
using Atomicy.App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Atomicy.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44313/")
            });

            builder.Services.AddHttpClient<IAtomicyManagementAPIClient, AtomicyManagementAPIClient>(client => client.BaseAddress = new Uri("https://localhost:44313/"));

            builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
             builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            await builder.Build().RunAsync();
        }
    }
}
