using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.BookFormats.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class BookFormatsEdgeCasesIntegrationTests
{
    private readonly HttpClient _client;

    public BookFormatsEdgeCasesIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetBookFormats_WithPageSizeOne_ReturnsSingleItem()
    {
        var response = await _client.GetAsync("/api/bookformats?Paging.PageSize=1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBookFormatsQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(1, body.Items.Count);
    }

    [Fact]
    public async Task GetBookFormats_AllIdsAreUnique()
    {
        var response = await _client.GetAsync("/api/bookformats?Paging.PageSize=100");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBookFormatsQueryDto>>();
        Assert.NotNull(body);
        var ids = body.Items.Select(f => f.Id).ToList();
        Assert.Equal(ids.Count, ids.Distinct().Count());
    }

    [Fact]
    public async Task GetBookFormats_TotalItemsConsistentAcrossPageSizes()
    {
        var r1 = await (await _client.GetAsync("/api/bookformats?Paging.PageSize=1")).Content
            .ReadFromJsonAsync<PageResult<ListBookFormatsQueryDto>>();
        var r2 = await (await _client.GetAsync("/api/bookformats?Paging.PageSize=100")).Content
            .ReadFromJsonAsync<PageResult<ListBookFormatsQueryDto>>();

        Assert.NotNull(r1);
        Assert.NotNull(r2);
        Assert.Equal(r1.TotalItems, r2.TotalItems);
    }

    [Fact]
    public async Task GetBookFormats_ContainsHardcoverFormat()
    {
        var response = await _client.GetAsync("/api/bookformats?Paging.PageSize=100");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBookFormatsQueryDto>>();
        Assert.NotNull(body);
        Assert.Contains(body.Items, f => f.Format.Contains("uvez"));
    }

    [Fact]
    public async Task GetBookFormats_SecondPage_ReturnsPageTwo()
    {
        var response = await _client.GetAsync("/api/bookformats?Paging.Page=2&Paging.PageSize=1");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBookFormatsQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(2, body.CurrentPage);
    }
}
