using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Authors.Queries.GetById;
using BookVerse.Application.Modules.Catalog.Authors.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class AuthorsIntegrationTests
{
    private readonly HttpClient _client;

    public AuthorsIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAuthors_Anonymous_ReturnsOkWithSeededAuthors()
    {
        var response = await _client.GetAsync("/Authors");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListAuthorsQueryDto>>();
        Assert.NotNull(body);
        Assert.NotNull(body.Items);
        Assert.NotEmpty(body.Items);
    }

    [Fact]
    public async Task GetAuthors_ReturnsPagedResult()
    {
        var response = await _client.GetAsync("/Authors");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListAuthorsQueryDto>>();
        Assert.NotNull(body);
        Assert.True(body.TotalItems > 0);
        Assert.True(body.PageSize > 0);
    }

    [Fact]
    public async Task GetAuthorById_ExistingId_ReturnsOkWithAuthor()
    {
        var response = await _client.GetAsync("/Authors/1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<GetAuthorByIdQueryDto>();
        Assert.NotNull(body);
        Assert.Equal(1, body.Id);
        Assert.NotEmpty(body.FirstName);
    }

    [Fact]
    public async Task GetAuthorById_NonExistingId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/Authors/999999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
