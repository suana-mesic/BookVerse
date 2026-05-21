using BookVerse.Application.Modules.Auth.Commands.Login;
using BookVerse.Application.Modules.Auth.Commands.Register;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.AuthTests.IntegrationTests;

[Collection("Integration")]
public class AuthIntegrationTests
{
    private readonly HttpClient _client;

    public AuthIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Login_WithValidCredentials_ReturnsOkWithToken()
    {
        // Captcha is required server-side, so every test that wants to exercise the login
        // path (and not be stopped at the captcha check) must fetch a real challenge first.
        var (captchaToken, captchaAnswer) = await CustomWebApplicationFactory<Program>.FetchCaptchaAsync(_client);
        var request = new
        {
            Email = "admin@bookverse.com",
            Password = "string",
            CaptchaToken = captchaToken,
            CaptchaAnswer = captchaAnswer
        };

        var response = await _client.PostAsJsonAsync("api/auth/login", request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<LoginCommandDto>();
        Assert.NotNull(body);
        Assert.NotNull(body.AccessToken);
        Assert.NotEmpty(body.AccessToken);
    }

    [Fact]
    public async Task Login_WithInvalidPassword_ReturnsUnauthorized()
    {
        // Per tačka 21, auth failures now map to 401 instead of 409 so the frontend
        // interceptor can distinguish auth issues from generic business conflicts.
        var (captchaToken, captchaAnswer) = await CustomWebApplicationFactory<Program>.FetchCaptchaAsync(_client);
        var request = new
        {
            Email = "admin@bookverse.com",
            Password = "wrong_password",
            CaptchaToken = captchaToken,
            CaptchaAnswer = captchaAnswer
        };

        var response = await _client.PostAsJsonAsync("api/auth/login", request);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Login_WithNonExistingUser_ReturnsNotFound()
    {
        // Captcha must pass before the handler ever runs the "does this user exist" check.
        var (captchaToken, captchaAnswer) = await CustomWebApplicationFactory<Program>.FetchCaptchaAsync(_client);
        var request = new
        {
            Email = "doesnotexist@bookverse.com",
            Password = "string",
            CaptchaToken = captchaToken,
            CaptchaAnswer = captchaAnswer
        };

        var response = await _client.PostAsJsonAsync("api/auth/login", request);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Login_WithEmptyEmail_ReturnsBadRequest()
    {
        // No captcha needed: FluentValidation rejects the empty email BEFORE the handler runs,
        // so we never reach the captcha check.
        var request = new { Email = "", Password = "string" };

        var response = await _client.PostAsJsonAsync("api/auth/login", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithValidData_ReturnsOk()
    {
        var uniqueEmail = $"test-{Guid.NewGuid():N}@bookverse.com";
        var (captchaToken, captchaAnswer) = await CustomWebApplicationFactory<Program>.FetchCaptchaAsync(_client);

        var request = new RegisterCommand
        {
            FirstName = "Test",
            LastName  = "User",
            Email     = uniqueEmail,
            Password  = "password123",
            Line1     = "Test Street 1",
            City      = "Sarajevo",
            Country   = "Bosnia and Herzegovina",
            CaptchaToken = captchaToken,
            CaptchaAnswer = captchaAnswer
        };

        var response = await _client.PostAsJsonAsync("api/auth/register", request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithDuplicateEmail_ReturnsConflict()
    {
        // Captcha must pass first; the "email already taken" check then runs inside the handler.
        var (captchaToken, captchaAnswer) = await CustomWebApplicationFactory<Program>.FetchCaptchaAsync(_client);
        var request = new RegisterCommand
        {
            FirstName = "Admin",
            LastName  = "Dup",
            Email     = "admin@bookverse.com",
            Password  = "password123",
            Line1     = "Test Street 1",
            City      = "Sarajevo",
            Country   = "Bosnia and Herzegovina",
            CaptchaToken = captchaToken,
            CaptchaAnswer = captchaAnswer
        };

        var response = await _client.PostAsJsonAsync("api/auth/register", request);

        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
    }
}
