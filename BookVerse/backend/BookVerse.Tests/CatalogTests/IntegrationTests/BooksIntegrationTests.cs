using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Book.Queries.GetById;
using BookVerse.Application.Modules.Catalog.Book.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class BooksIntegrationTests
{
    private readonly HttpClient _client;

    public BooksIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetBooks_Anonymous_ReturnsOkWithSeededBooks()
    {
        var response = await _client.GetAsync("/Books");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
        Assert.NotNull(body.Items);
        Assert.NotEmpty(body.Items);
    }

    [Fact]
    public async Task GetBooks_ReturnsPagedResult()
    {
        var response = await _client.GetAsync("/Books");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
        Assert.True(body.TotalItems > 0);
        Assert.True(body.PageSize > 0);
    }

    [Fact]
    public async Task GetBookById_ExistingId_ReturnsOkWithBook()
    {
        var response = await _client.GetAsync("/Books/1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<GetBookByIdQueryDto>();
        Assert.NotNull(body);
        Assert.Equal(1, body.Id);
        Assert.NotEmpty(body.Title);
    }

    [Fact]
    public async Task GetBookById_NonExistingId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/Books/999999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
