using BookVerse.Application.Modules.Auth.Commands.Login;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BookVerse.Tests;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<Program>
{
    private static string? _cachedToken;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("IntegrationTests");

        builder.ConfigureAppConfiguration((_, config) =>
        {
            config.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:Main"]       = "Server=localhost;Database=BookVerseIntegrationTests;",
                ["Jwt:Issuer"]                   = "BookVerse.Api",
                ["Jwt:Audience"]                 = "BookVerse.Spa",
                ["Jwt:Key"]                      = "integration-tests-super-secret-jwt-key-minimum-32-chars!!",
                ["Jwt:AccessTokenMinutes"]       = "20",
                ["Jwt:RefreshTokenDays"]         = "14",
                ["CaptchaOptions:SecretKey"]     = "integration-test-captcha-secret-key-32chars",
                ["Stripe:SecretKey"]             = "sk_test_dummy",
                ["Stripe:PublishableKey"]        = "pk_test_dummy",
                ["Stripe:WebhookSecret"]         = "whsec_dummy",
                ["EmailSettings:Host"]           = "localhost",
                ["EmailSettings:Port"]           = "25",
                ["EmailSettings:Username"]       = "test",
                ["EmailSettings:Password"]       = "test",
                ["EmailSettings:FromName"]       = "BookVerse Test",
                ["EmailSettings:FromEmail"]      = "test@bookverse.com",
                ["EmailSettings:EnableSsl"]      = "false",
                ["FrontendUrl"]                  = "http://localhost:4200"
            });
        });
    }

    public async Task<HttpClient> GetAuthenticatedClientAsync()
    {
        var client = CreateClient();
        if (string.IsNullOrEmpty(_cachedToken))
        {
            var loginRequest = new
            {
                Email = "admin@bookverse.com",
                Password = "string"
            };

            var response = await client.PostAsJsonAsync("api/auth/login", loginRequest);
            response.EnsureSuccessStatusCode();

            var loginResponse = await response.Content.ReadFromJsonAsync<LoginCommandDto>();
            _cachedToken = loginResponse!.AccessToken;
        }
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _cachedToken);
        return client;
    }
}
