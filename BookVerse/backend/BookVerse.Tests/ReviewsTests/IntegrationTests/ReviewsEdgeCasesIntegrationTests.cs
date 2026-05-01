using BookVerse.Application.Common;
using BookVerse.Application.Modules.Reviews.Queries.ListForBook;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.ReviewsTests.IntegrationTests;

[Collection("Integration")]
public class ReviewsEdgeCasesIntegrationTests
{
    private readonly HttpClient _client;

    public ReviewsEdgeCasesIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetReviewsForBook_SeededBook_RatingsAreInValidRange()
    {
        var response = await _client.GetAsync("/Reviews/1/all");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListReviewsForBookQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body.Items, r =>
        {
            Assert.True(r.Rating >= 1 && r.Rating <= 5);
        });
    }

    [Fact]
    public async Task GetReviewsForBook_SeededBook_CommentsAreNotEmpty()
    {
        var response = await _client.GetAsync("/Reviews/1/all");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListReviewsForBookQueryDto>>();
        Assert.NotNull(body);
        Assert.All(body.Items, r => Assert.NotEmpty(r.Comment));
    }

    [Fact]
    public async Task GetReviewsForBook_DefaultPage_IsPageOne()
    {
        var response = await _client.GetAsync("/Reviews/1/all");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListReviewsForBookQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(1, body.CurrentPage);
    }

    [Fact]
    public async Task GetReviewsForBook_VeryLargeBookId_ReturnsOkWithEmptyList()
    {
        var response = await _client.GetAsync("/Reviews/2147483647/all");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListReviewsForBookQueryDto>>();
        Assert.NotNull(body);
        Assert.Empty(body.Items);
    }
}
