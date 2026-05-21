using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Authors.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class AuthorsFilterIntegrationTests
{
    private readonly HttpClient _client;

    public AuthorsFilterIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAuthors_WithPageSizeOne_ReturnsSingleItem()
    {
        var response = await _client.GetAsync("/api/authors?Paging.PageSize=1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListAuthorsQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(1, body.Items.Count);
    }

    [Fact]
    public async Task GetAuthors_WithSearchTerm_ReturnsMatchingAuthors()
    {
        var response = await _client.GetAsync("/api/authors?search=Meša");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListAuthorsQueryDto>>();
        Assert.NotNull(body);
        Assert.NotEmpty(body.Items);
    }

    [Fact]
    public async Task GetAuthors_WithNonExistentSearch_ReturnsEmptyList()
    {
        var response = await _client.GetAsync("/api/authors?search=ZZZNikoNe");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListAuthorsQueryDto>>();
        Assert.NotNull(body);
        Assert.Empty(body.Items);
    }

    [Fact]
    public async Task GetAuthors_SecondPage_ReturnsCorrectPageNumber()
    {
        var response = await _client.GetAsync("/api/authors?Paging.Page=2&Paging.PageSize=1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListAuthorsQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(2, body.CurrentPage);
    }

    [Fact]
    public async Task GetAuthors_ItemsHaveFirstAndLastName()
    {
        var response = await _client.GetAsync("/api/authors");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListAuthorsQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body.Items, a =>
        {
            Assert.NotEmpty(a.FirstName);
            Assert.NotEmpty(a.LastName);
        });
    }

    [Fact]
    public async Task GetAuthors_TotalItemsConsistentAcrossPageSizes()
    {
        var r1 = await (await _client.GetAsync("/api/authors?Paging.PageSize=1")).Content
            .ReadFromJsonAsync<PageResult<ListAuthorsQueryDto>>();
        var r2 = await (await _client.GetAsync("/api/authors?Paging.PageSize=50")).Content
            .ReadFromJsonAsync<PageResult<ListAuthorsQueryDto>>();

        Assert.NotNull(r1);
        Assert.NotNull(r2);
        Assert.Equal(r1.TotalItems, r2.TotalItems);
    }
}
