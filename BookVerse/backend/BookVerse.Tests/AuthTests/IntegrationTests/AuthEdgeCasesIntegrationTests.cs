using BookVerse.Application.Modules.Auth.Commands.Register;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.AuthTests.IntegrationTests;

[Collection("Integration")]
public class AuthEdgeCasesIntegrationTests
{
    private readonly HttpClient _client;

    public AuthEdgeCasesIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Login_WithMissingPassword_ReturnsBadRequest()
    {
        var request = new { Email = "admin@bookverse.com" };

        var response = await _client.PostAsJsonAsync("api/auth/login", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Login_WithMissingEmail_ReturnsBadRequest()
    {
        var request = new { Password = "string" };

        var response = await _client.PostAsJsonAsync("api/auth/login", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithEmptyFirstName_ReturnsBadRequest()
    {
        var request = new RegisterCommand
        {
            FirstName = "",
            LastName = "Test",
            Email = $"test-{Guid.NewGuid():N}@bookverse.com",
            Password = "password123",
            Line1 = "Street 1",
            City = "Sarajevo",
            Country = "Bosnia and Herzegovina"
        };

        var response = await _client.PostAsJsonAsync("api/auth/register", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithShortPassword_ReturnsBadRequest()
    {
        var request = new RegisterCommand
        {
            FirstName = "Test",
            LastName = "User",
            Email = $"test-{Guid.NewGuid():N}@bookverse.com",
            Password = "abc",
            Line1 = "Street 1",
            City = "Sarajevo",
            Country = "Bosnia and Herzegovina"
        };

        var response = await _client.PostAsJsonAsync("api/auth/register", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithEmptyCity_ReturnsBadRequest()
    {
        var request = new RegisterCommand
        {
            FirstName = "Test",
            LastName = "User",
            Email = $"test-{Guid.NewGuid():N}@bookverse.com",
            Password = "password123",
            Line1 = "Street 1",
            City = "",
            Country = "Bosnia and Herzegovina"
        };

        var response = await _client.PostAsJsonAsync("api/auth/register", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithEmptyCountry_ReturnsBadRequest()
    {
        var request = new RegisterCommand
        {
            FirstName = "Test",
            LastName = "User",
            Email = $"test-{Guid.NewGuid():N}@bookverse.com",
            Password = "password123",
            Line1 = "Street 1",
            City = "Sarajevo",
            Country = ""
        };

        var response = await _client.PostAsJsonAsync("api/auth/register", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithMultipleUniqueEmails_AllReturnOk()
    {
        // Each iteration is a real register call that has to pass captcha verification,
        // so we fetch a fresh captcha challenge before each one. The captcha endpoint is
        // anonymous and cheap (in-memory image + HMAC), so doing it 3 times is fine.
        for (int i = 0; i < 3; i++)
        {
            var (captchaToken, captchaAnswer) = await CustomWebApplicationFactory<Program>.FetchCaptchaAsync(_client);
            var request = new RegisterCommand
            {
                FirstName = "Test",
                LastName = "User",
                Email = $"test-{Guid.NewGuid():N}@bookverse.com",
                Password = "password123",
                Line1 = "Street 1",
                City = "Sarajevo",
                Country = "Bosnia and Herzegovina",
                CaptchaToken = captchaToken,
                CaptchaAnswer = captchaAnswer
            };

            var response = await _client.PostAsJsonAsync("api/auth/register", request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
