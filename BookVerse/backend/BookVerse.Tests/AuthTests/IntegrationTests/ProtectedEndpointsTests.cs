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
        var response = await _client.GetAsync("/Cart");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetMyOrders_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/OrdersOrderItems/my-orders");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetMyProfile_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/Users/my-profile");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetAllUsers_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/Users/all-users");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetReviewForBook_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/Reviews/1");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetAdminOrders_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/OrdersOrderItems");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetUserAddress_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/Users/user-address");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GenerateCaptcha_WithoutAuth_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/Captcha/generate");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
