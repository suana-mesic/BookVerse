using BookVerse.Application.Modules.Catalog.Languages.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class LanguagesEdgeCasesIntegrationTests
{
    private readonly HttpClient _client;

    public LanguagesEdgeCasesIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetLanguages_AllIdsAreUnique()
    {
        var response = await _client.GetAsync("/Languages");

        var body = await response.Content.ReadFromJsonAsync<List<ListLanguagesQueryDto>>();
        Assert.NotNull(body);
        var ids = body.Select(l => l.Id).ToList();
        Assert.Equal(ids.Count, ids.Distinct().Count());
    }

    [Fact]
    public async Task GetLanguages_AllNamesAreUnique()
    {
        var response = await _client.GetAsync("/Languages");

        var body = await response.Content.ReadFromJsonAsync<List<ListLanguagesQueryDto>>();
        Assert.NotNull(body);
        var names = body.Select(l => l.Name).ToList();
        Assert.Equal(names.Count, names.Distinct().Count());
    }

    [Fact]
    public async Task GetLanguages_ContainsBosanski()
    {
        var response = await _client.GetAsync("/Languages");

        var body = await response.Content.ReadFromJsonAsync<List<ListLanguagesQueryDto>>();
        Assert.NotNull(body);
        Assert.Contains(body, l => l.Name == "Bosanski");
    }

    [Fact]
    public async Task GetLanguages_ContainsEngleski()
    {
        var response = await _client.GetAsync("/Languages");

        var body = await response.Content.ReadFromJsonAsync<List<ListLanguagesQueryDto>>();
        Assert.NotNull(body);
        Assert.Contains(body, l => l.Name == "Engleski");
    }

    [Fact]
    public async Task GetLanguages_ReturnsCorrectContentType()
    {
        var response = await _client.GetAsync("/Languages");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
    }
}
