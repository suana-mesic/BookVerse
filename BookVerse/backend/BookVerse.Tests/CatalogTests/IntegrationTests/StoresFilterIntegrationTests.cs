using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Stores.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class StoresFilterIntegrationTests
{
    private readonly HttpClient _client;

    public StoresFilterIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetStores_WithPageSizeOne_ReturnsSingleItem()
    {
        var response = await _client.GetAsync("/Stores?Paging.PageSize=1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListStoresQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(1, body.Items.Count);
    }

    [Fact]
    public async Task GetStores_SecondPage_ReturnsPageTwo()
    {
        var response = await _client.GetAsync("/Stores?Paging.Page=2&Paging.PageSize=1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListStoresQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(2, body.CurrentPage);
    }

    [Fact]
    public async Task GetStores_TotalItemsConsistentAcrossPageSizes()
    {
        var r1 = await (await _client.GetAsync("/Stores?Paging.PageSize=1")).Content
            .ReadFromJsonAsync<PageResult<ListStoresQueryDto>>();
        var r2 = await (await _client.GetAsync("/Stores?Paging.PageSize=100")).Content
            .ReadFromJsonAsync<PageResult<ListStoresQueryDto>>();

        Assert.NotNull(r1);
        Assert.NotNull(r2);
        Assert.Equal(r1.TotalItems, r2.TotalItems);
    }

    [Fact]
    public async Task GetStores_ItemsContainContactInfo()
    {
        var response = await _client.GetAsync("/Stores");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListStoresQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body.Items, s =>
        {
            Assert.NotEmpty(s.Phone);
            Assert.NotEmpty(s.Email);
            Assert.NotEmpty(s.OpeningHours);
        });
    }

    [Fact]
    public async Task GetStoreById_Two_ReturnsOk()
    {
        var response = await _client.GetAsync("/Stores/2");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
