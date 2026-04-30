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
        var request = new { Email = "admin@bookverse.com", Password = "string" };

        var response = await _client.PostAsJsonAsync("api/auth/login", request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<LoginCommandDto>();
        Assert.NotNull(body);
        Assert.NotNull(body.AccessToken);
        Assert.NotEmpty(body.AccessToken);
    }

    [Fact]
    public async Task Login_WithInvalidPassword_ReturnsConflict()
    {
        var request = new { Email = "admin@bookverse.com", Password = "wrong_password" };

        var response = await _client.PostAsJsonAsync("api/auth/login", request);

        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
    }

    [Fact]
    public async Task Login_WithNonExistingUser_ReturnsNotFound()
    {
        var request = new { Email = "doesnotexist@bookverse.com", Password = "string" };

        var response = await _client.PostAsJsonAsync("api/auth/login", request);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Login_WithEmptyEmail_ReturnsBadRequest()
    {
        var request = new { Email = "", Password = "string" };

        var response = await _client.PostAsJsonAsync("api/auth/login", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithValidData_ReturnsOk()
    {
        var uniqueEmail = $"test-{Guid.NewGuid():N}@bookverse.com";

        var request = new RegisterCommand
        {
            FirstName = "Test",
            LastName  = "User",
            Email     = uniqueEmail,
            Password  = "password123",
            Line1     = "Test Street 1",
            City      = "Sarajevo",
            Country   = "Bosnia and Herzegovina"
        };

        var response = await _client.PostAsJsonAsync("api/auth/register", request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithDuplicateEmail_ReturnsConflict()
    {
        var request = new RegisterCommand
        {
            FirstName = "Admin",
            LastName  = "Dup",
            Email     = "admin@bookverse.com",
            Password  = "password123",
            Line1     = "Test Street 1",
            City      = "Sarajevo",
            Country   = "Bosnia and Herzegovina"
        };

        var response = await _client.PostAsJsonAsync("api/auth/register", request);

        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
    }
}
