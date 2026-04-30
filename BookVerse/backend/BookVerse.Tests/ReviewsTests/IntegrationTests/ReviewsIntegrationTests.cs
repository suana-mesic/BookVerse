using BookVerse.Application.Common;
using BookVerse.Application.Modules.Reviews.Queries.ListForBook;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.ReviewsTests.IntegrationTests;

[Collection("Integration")]
public class ReviewsIntegrationTests
{
    private readonly HttpClient _client;

    public ReviewsIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllReviewsForBook_SeededBook_ReturnsOkWithReviews()
    {
        var response = await _client.GetAsync("/Reviews/1/all");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListReviewsForBookQueryDto>>();
        Assert.NotNull(body);
        Assert.NotNull(body.Items);
    }

    [Fact]
    public async Task GetAllReviewsForBook_NonExistingBook_ReturnsOkWithEmptyList()
    {
        var response = await _client.GetAsync("/Reviews/999999/all");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListReviewsForBookQueryDto>>();
        Assert.NotNull(body);
        Assert.Empty(body.Items);
    }
}
