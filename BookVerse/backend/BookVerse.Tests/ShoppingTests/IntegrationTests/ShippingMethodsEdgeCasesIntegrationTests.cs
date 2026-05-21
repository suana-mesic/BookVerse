using BookVerse.Application.Modules.Shopping.ShippingMethods.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.ShoppingTests.IntegrationTests;

[Collection("Integration")]
public class ShippingMethodsEdgeCasesIntegrationTests
{
    private readonly HttpClient _client;

    public ShippingMethodsEdgeCasesIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetShippingMethods_ReturnsAtLeastThreeMethods()
    {
        var response = await _client.GetAsync("/api/shippingmethods");

        var body = await response.Content.ReadFromJsonAsync<List<ListShippingMethodsQueryDto>>();
        Assert.NotNull(body);
        Assert.True(body.Count >= 3);
    }

    [Fact]
    public async Task GetShippingMethods_AllMethodsHavePositivePrice()
    {
        var response = await _client.GetAsync("/api/shippingmethods");

        var body = await response.Content.ReadFromJsonAsync<List<ListShippingMethodsQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body, m => Assert.True(m.Price > 0));
    }

    [Fact]
    public async Task GetShippingMethods_AllMethodsHaveDescription()
    {
        var response = await _client.GetAsync("/api/shippingmethods");

        var body = await response.Content.ReadFromJsonAsync<List<ListShippingMethodsQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body, m => Assert.NotEmpty(m.Description));
    }

    [Fact]
    public async Task GetShippingMethods_AllIdsAreUnique()
    {
        var response = await _client.GetAsync("/api/shippingmethods");

        var body = await response.Content.ReadFromJsonAsync<List<ListShippingMethodsQueryDto>>();
        Assert.NotNull(body);
        var ids = body.Select(m => m.Id).ToList();
        Assert.Equal(ids.Count, ids.Distinct().Count());
    }
}
