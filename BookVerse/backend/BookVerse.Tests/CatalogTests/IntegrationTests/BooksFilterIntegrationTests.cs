using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Book.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class BooksFilterIntegrationTests
{
    private readonly HttpClient _client;

    public BooksFilterIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetBooks_WithPageSizeOne_ReturnsSingleItem()
    {
        var response = await _client.GetAsync("/Books?Paging.PageSize=1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(1, body.Items.Count);
    }

    [Fact]
    public async Task GetBooks_WithPageSizeTwo_ReturnsAtMostTwoItems()
    {
        var response = await _client.GetAsync("/Books?Paging.PageSize=2");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
        Assert.True(body.Items.Count <= 2);
    }

    [Fact]
    public async Task GetBooks_WithSearchTerm_ReturnsMatchingBooks()
    {
        var response = await _client.GetAsync("/Books?search=Derviš");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
        Assert.NotEmpty(body.Items);
    }

    [Fact]
    public async Task GetBooks_WithNonExistentSearch_ReturnsEmptyList()
    {
        var response = await _client.GetAsync("/Books?search=XYZ999NonExistent");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
        Assert.Empty(body.Items);
    }

    [Fact]
    public async Task GetBooks_SecondPage_ReturnsCorrectPage()
    {
        var response = await _client.GetAsync("/Books?Paging.Page=2&Paging.PageSize=2");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(2, body.CurrentPage);
    }

    [Fact]
    public async Task GetBooks_TotalItemsMatchesAcrossPages()
    {
        var page1 = await _client.GetAsync("/Books?Paging.PageSize=100");
        var body1 = await page1.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();

        var page2 = await _client.GetAsync("/Books?Paging.PageSize=2");
        var body2 = await page2.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();

        Assert.NotNull(body1);
        Assert.NotNull(body2);
        Assert.Equal(body1.TotalItems, body2.TotalItems);
    }

    [Fact]
    public async Task GetBooks_WithLanguageFilter_ReturnsOk()
    {
        var response = await _client.GetAsync("/Books?language=Bosanski");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
    }

    [Fact]
    public async Task GetBooks_ItemsHaveRequiredFields()
    {
        var response = await _client.GetAsync("/Books");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListBooksQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body.Items, b =>
        {
            Assert.True(b.Id > 0);
            Assert.NotEmpty(b.Title);
            Assert.True(b.Price > 0);
        });
    }
}
