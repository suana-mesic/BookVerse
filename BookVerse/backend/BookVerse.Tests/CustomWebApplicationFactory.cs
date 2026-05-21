using BookVerse.Application.Common.Interfaces;
using BookVerse.Application.Modules.Auth.Commands.Login;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BookVerse.Tests;

// Shape of what GET /captcha/generate returns. Defined here so the test factory can
// deserialize without depending on the API-side DTO class.
public sealed record CaptchaChallenge(string Image, string Token);

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
                ["Payment:Currency"]             = "bam",
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

        builder.ConfigureTestServices(services =>
        {
            // Replace the real CaptchaVerifier with a no-op for integration tests. The captcha
            // token now carries only the HMAC of the answer (security fix), so tests can no
            // longer extract the plaintext answer from the token. OCR'ing the captcha image
            // is impractical in CI, and captcha behaviour itself is covered by the captcha
            // unit tests - here we only want the auth flow to run end-to-end.
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(ICaptchaVerifier));
            if (descriptor != null) services.Remove(descriptor);
            services.AddSingleton<ICaptchaVerifier, NoOpCaptchaVerifier>();
        });
    }

    // Test-only captcha verifier that always succeeds. Registered in ConfigureTestServices
    // above so the real CaptchaVerifier is never executed during integration tests.
    private sealed class NoOpCaptchaVerifier : ICaptchaVerifier
    {
        public Task VerifyAsync(string token, string answer, CancellationToken ct)
            => Task.CompletedTask;
    }

    public async Task<HttpClient> GetAuthenticatedClientAsync()
    {
        var client = CreateClient();
        if (string.IsNullOrEmpty(_cachedToken))
        {
            // Captcha is now required by the login endpoint, so we fetch a real captcha
            // challenge and include the (token, answer) pair the same way the frontend does.
            var (captchaToken, captchaAnswer) = await FetchCaptchaAsync(client);

            var loginRequest = new
            {
                Email = "admin@bookverse.com",
                Password = "string",
                CaptchaToken = captchaToken,
                CaptchaAnswer = captchaAnswer
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

    // Test helper that returns dummy (token, answer) values. The real captcha verifier is
    // swapped for NoOpCaptchaVerifier in ConfigureTestServices, so these values are never
    // actually validated - they only need to be non-null strings the request payload accepts.
    //
    // Previously this method fetched a real challenge from /api/captcha/generate and pulled
    // the plaintext answer out of the token payload. That stopped working when the captcha
    // was hardened to embed only an HMAC of the answer (not the plaintext) in the token.
    public static Task<(string Token, string Answer)> FetchCaptchaAsync(HttpClient client)
    {
        return Task.FromResult(("integration-test-token", "TESTS"));
    }
}
