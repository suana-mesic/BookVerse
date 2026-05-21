using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Book.Queries.GetById;
using BookVerse.Application.Modules.Catalog.Book.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class BooksEdgeCasesIntegrationTests
{
    private readonly HttpClient _client;

    public BooksEdgeCasesIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async Task GetBookById_SeededBooks_AllReturnOk(int bookId)
    {
        var response = await _client.GetAsync($"/api/books/{bookId}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<GetBookByIdQueryDto>();
        Assert.NotNull(body);
        Assert.Equal(bookId, body.Id);
    }

    [Theory]
    [InlineData(999998)]
    [InlineData(999999)]
    public async Task GetBookById_NonExistentIds_ReturnsNotFound(int bookId)
    {
        var response = await _client.GetAsync($"/api/books/{bookId}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task GetBookById_InvalidIds_ReturnsBadRequest(int bookId)
    {
        var response = await _client.GetAsync($"/api/books/{bookId}");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetBooks_DefaultPage_IsPageOne()
    {
        var response = await _client.GetAsync("/api/books");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(1, body.CurrentPage);
    }

    [Fact]
    public async Task GetBooks_AllItemsHavePositivePrice()
    {
        var response = await _client.GetAsync("/api/books?Paging.PageSize=100");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body.Items, b => Assert.True(b.Price > 0));
    }

    [Fact]
    public async Task GetBooks_AllItemsHavePositiveId()
    {
        var response = await _client.GetAsync("/api/books?Paging.PageSize=100");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body.Items, b => Assert.True(b.Id > 0));
    }

    [Fact]
    public async Task GetBooks_SearchIsCaseInsensitive()
    {
        var lower = await (await _client.GetAsync("/api/books?search=derviš")).Content
            .ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        var upper = await (await _client.GetAsync("/api/books?search=DERVIŠ")).Content
            .ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();

        Assert.NotNull(lower);
        Assert.NotNull(upper);
        Assert.Equal(lower.TotalItems, upper.TotalItems);
    }
}
