using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Stores.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class StoresIntegrationTests
{
    private readonly HttpClient _client;

    public StoresIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetStores_Anonymous_ReturnsOkWithSeededStores()
    {
        var response = await _client.GetAsync("/api/stores");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListStoresQueryDto>>();
        Assert.NotNull(body);
        Assert.NotNull(body.Items);
        Assert.NotEmpty(body.Items);
    }

    [Fact]
    public async Task GetStores_ReturnsPagedResult()
    {
        var response = await _client.GetAsync("/api/stores");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListStoresQueryDto>>();
        Assert.NotNull(body);
        Assert.True(body.TotalItems > 0);
        Assert.True(body.PageSize > 0);
    }

    [Fact]
    public async Task GetStores_EachItemHasRequiredFields()
    {
        var response = await _client.GetAsync("/api/stores");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListStoresQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body.Items, s =>
        {
            Assert.True(s.Id > 0);
            Assert.NotEmpty(s.StoreName);
        });
    }

    [Fact]
    public async Task GetStoreById_ExistingId_ReturnsOk()
    {
        var response = await _client.GetAsync("/api/stores/1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetStoreById_NonExistingId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/stores/999999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
