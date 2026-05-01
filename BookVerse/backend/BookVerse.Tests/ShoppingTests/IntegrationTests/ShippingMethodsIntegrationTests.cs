using BookVerse.Application.Modules.Shopping.ShippingMethods.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.ShoppingTests.IntegrationTests;

[Collection("Integration")]
public class ShippingMethodsIntegrationTests
{
    private readonly HttpClient _client;

    public ShippingMethodsIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetShippingMethods_Anonymous_ReturnsOk()
    {
        var response = await _client.GetAsync("/ShippingMethods");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetShippingMethods_ReturnsSeededMethods()
    {
        var response = await _client.GetAsync("/ShippingMethods");

        var body = await response.Content.ReadFromJsonAsync<List<ListShippingMethodsQueryDto>>();
        Assert.NotNull(body);
        Assert.NotEmpty(body);
    }

    [Fact]
    public async Task GetShippingMethods_EachMethodHasNameAndPrice()
    {
        var response = await _client.GetAsync("/ShippingMethods");

        var body = await response.Content.ReadFromJsonAsync<List<ListShippingMethodsQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body, m =>
        {
            Assert.True(m.Id > 0);
            Assert.NotEmpty(m.Name);
            Assert.True(m.Price > 0);
        });
    }
}
