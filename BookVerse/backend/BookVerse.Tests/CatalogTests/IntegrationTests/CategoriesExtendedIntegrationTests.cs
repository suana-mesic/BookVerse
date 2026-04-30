using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Categories.Queries.GetById;
using BookVerse.Application.Modules.Catalog.Categories.Queries.ListPaged;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class CategoriesExtendedIntegrationTests
{
    private readonly HttpClient _client;

    public CategoriesExtendedIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetCategoryById_ExistingId_ReturnsOkWithCategory()
    {
        var response = await _client.GetAsync("/Categories/1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<GetCategoryByIdQueryDto>();
        Assert.NotNull(body);
        Assert.Equal(1, body.Id);
        Assert.NotEmpty(body.Name);
    }

    [Fact]
    public async Task GetCategoryById_NonExistingId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/Categories/999999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetCategoriesPaged_ReturnsOkWithPagedResult()
    {
        var response = await _client.GetAsync("/Categories/list-paged");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListCategoriesPagedQueryDto>>();
        Assert.NotNull(body);
        Assert.True(body.TotalItems > 0);
    }

    [Fact]
    public async Task GetCategoriesPaged_EachItemHasName()
    {
        var response = await _client.GetAsync("/Categories/list-paged");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListCategoriesPagedQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body.Items, c => Assert.NotEmpty(c.Name));
    }
}
