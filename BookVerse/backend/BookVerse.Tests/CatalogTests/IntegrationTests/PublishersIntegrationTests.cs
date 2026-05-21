using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Publishers.Queries.GetById;
using BookVerse.Application.Modules.Catalog.Publishers.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class PublishersIntegrationTests
{
    private readonly HttpClient _client;

    public PublishersIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetPublishers_Anonymous_ReturnsOkWithSeededPublishers()
    {
        var response = await _client.GetAsync("/api/publishers");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListPublishersQueryDto>>();
        Assert.NotNull(body);
        Assert.NotNull(body.Items);
        Assert.NotEmpty(body.Items);
    }

    [Fact]
    public async Task GetPublishers_ReturnsPagedResult()
    {
        var response = await _client.GetAsync("/api/publishers");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListPublishersQueryDto>>();
        Assert.NotNull(body);
        Assert.True(body.TotalItems > 0);
    }

    [Fact]
    public async Task GetPublisherById_ExistingId_ReturnsOkWithPublisher()
    {
        var response = await _client.GetAsync("/api/publishers/1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<GetPublisherByIdQueryDto>();
        Assert.NotNull(body);
        Assert.Equal(1, body.Id);
        Assert.NotEmpty(body.Name);
    }

    [Fact]
    public async Task GetPublisherById_NonExistingId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/publishers/999999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
