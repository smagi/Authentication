using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace WebAuth.Client.Clients
{
    public static class AuthenticationHttpClientConfiguration
    { 
            public static void AddAuthenticationHttpClient(this WebAssemblyHostBuilder builder)
            {
                var authenticationHttpClientSettings = builder.Configuration
                    .GetSection(nameof(AuthenticationHttpClientSettings))
                    .Get<AuthenticationHttpClientSettings>();

                if (string.IsNullOrWhiteSpace(authenticationHttpClientSettings?.BaseAddress))
                    throw new InvalidOperationException("APIBaseAddress missing from appsettings file.");

                builder.Services.AddHttpClient<AuthenticationHttpClient>(client =>
                {
                    client.BaseAddress = new Uri("http://localhost:5013/");
                    //new Uri(authenticationHttpClientSettings.BaseAddress);
                });
            }
    }
}