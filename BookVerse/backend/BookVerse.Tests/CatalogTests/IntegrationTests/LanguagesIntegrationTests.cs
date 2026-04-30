using BookVerse.Application.Modules.Catalog.Languages.Queries.List;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.CatalogTests.IntegrationTests;

[Collection("Integration")]
public class LanguagesIntegrationTests
{
    private readonly HttpClient _client;

    public LanguagesIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetLanguages_Anonymous_ReturnsOkWithSeededLanguages()
    {
        var response = await _client.GetAsync("/Languages");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<List<ListLanguagesQueryDto>>();
        Assert.NotNull(body);
        Assert.NotEmpty(body);
    }

    [Fact]
    public async Task GetLanguages_ReturnsAtLeastNineLanguages()
    {
        var response = await _client.GetAsync("/Languages");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<List<ListLanguagesQueryDto>>();
        Assert.NotNull(body);
        Assert.True(body.Count >= 9);
    }

    [Fact]
    public async Task GetLanguages_EachItemHasNameAndId()
    {
        var response = await _client.GetAsync("/Languages");
        var body = await response.Content.ReadFromJsonAsync<List<ListLanguagesQueryDto>>();

        Assert.NotNull(body);
        Assert.All(body, lang =>
        {
            Assert.True(lang.Id > 0);
            Assert.NotEmpty(lang.Name);
        });
    }
}
