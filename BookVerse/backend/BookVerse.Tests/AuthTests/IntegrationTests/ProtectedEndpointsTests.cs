using System.Net;

namespace BookVerse.Tests.AuthTests.IntegrationTests;

[Collection("Integration")]
public class ProtectedEndpointsTests
{
    private readonly HttpClient _client;

    public ProtectedEndpointsTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetCart_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/api/cart");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetMyOrders_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/api/orders/my-orders");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetMyProfile_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/api/users/my-profile");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetAllUsers_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/api/users/all-users");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetReviewForBook_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/api/reviews/1");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetAdminOrders_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/api/orders");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetUserAddress_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/api/users/user-address");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GenerateCaptcha_WithoutAuth_ReturnsOk()
    {
        // Captcha is INTENTIONALLY anonymous now: it protects login/register/forgot-password,
        // all of which are themselves anonymous. Requiring a logged-in user to fetch a captcha
        // would defeat the whole purpose, so /api/captcha/generate must return 200 to everyone.
        var response = await _client.GetAsync("/api/captcha/generate");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
