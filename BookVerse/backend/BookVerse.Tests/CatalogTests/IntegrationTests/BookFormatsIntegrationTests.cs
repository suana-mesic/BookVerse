using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.BookFormats.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class BookFormatsIntegrationTests
{
    private readonly HttpClient _client;

    public BookFormatsIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetBookFormats_Anonymous_ReturnsOkWithSeededFormats()
    {
        var response = await _client.GetAsync("/api/bookformats");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBookFormatsQueryDto>>();
        Assert.NotNull(body);
        Assert.NotNull(body.Items);
        Assert.NotEmpty(body.Items);
    }

    [Fact]
    public async Task GetBookFormats_ReturnsAtLeastThreeFormats()
    {
        var response = await _client.GetAsync("/api/bookformats");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBookFormatsQueryDto>>();
        Assert.NotNull(body);
        Assert.True(body.TotalItems >= 3);
    }

    [Fact]
    public async Task GetBookFormats_EachItemHasFormatName()
    {
        var response = await _client.GetAsync("/api/bookformats");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBookFormatsQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body.Items, f =>
        {
            Assert.True(f.Id > 0);
            Assert.NotEmpty(f.Format);
        });
    }
}
