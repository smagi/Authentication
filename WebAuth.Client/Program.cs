using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAuth.Client;
using WebAuth.Client.Components;
using WebAuth.Client.Clients;
using WebAuth.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.AddAuthenticationHttpClient();

builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<CustomAuthenticationStateProvider>()
    .AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>())
    .AddScoped<IDateTimeService, DateTimeService>()
    .AddScoped<ITokenService, TokenService>()
    .AddScoped<ITokenValidationService, TokenValidatorServcie>()
    .AddScoped<IUserLoginService, UserLoginService>()
    .AddScoped<IUserRegistrationService, UserRegistrationService>()
    .AddScoped<IMessageAlertService, MessageAlertService>()
    .AddScoped<TokenValidator>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

