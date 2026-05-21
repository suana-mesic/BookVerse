using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Publishers.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class PublishersFilterIntegrationTests
{
    private readonly HttpClient _client;

    public PublishersFilterIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetPublishers_WithPageSizeOne_ReturnsSingleItem()
    {
        var response = await _client.GetAsync("/api/publishers?Paging.PageSize=1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListPublishersQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(1, body.Items.Count);
    }

    [Fact]
    public async Task GetPublishers_SecondPage_ReturnsCorrectPageNumber()
    {
        var response = await _client.GetAsync("/api/publishers?Paging.Page=2&Paging.PageSize=1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListPublishersQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(2, body.CurrentPage);
    }

    [Fact]
    public async Task GetPublishers_ItemsHaveRequiredFields()
    {
        var response = await _client.GetAsync("/api/publishers");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListPublishersQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body.Items, p =>
        {
            Assert.True(p.Id > 0);
            Assert.NotEmpty(p.Name);
        });
    }

    [Fact]
    public async Task GetPublishers_TotalItemsConsistentAcrossPageSizes()
    {
        var r1 = await (await _client.GetAsync("/api/publishers?Paging.PageSize=1")).Content
            .ReadFromJsonAsync<PageResult<ListPublishersQueryDto>>();
        var r2 = await (await _client.GetAsync("/api/publishers?Paging.PageSize=100")).Content
            .ReadFromJsonAsync<PageResult<ListPublishersQueryDto>>();

        Assert.NotNull(r1);
        Assert.NotNull(r2);
        Assert.Equal(r1.TotalItems, r2.TotalItems);
    }
}
