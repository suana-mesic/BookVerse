using BookVerse.Application.Common;
using BookVerse.Application.Modules.Reviews.Queries.ListForBook;
using System.Net;
using System.Net.Http.Json;

namespace BookVerse.Tests.ReviewsTests.IntegrationTests;

[Collection("Integration")]
public class ReviewsPaginationIntegrationTests
{
    private readonly HttpClient _client;

    public ReviewsPaginationIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetReviewsForBook_WithPageSizeOne_ReturnsAtMostOneItem()
    {
        var response = await _client.GetAsync("/Reviews/1/all?Paging.PageSize=1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListReviewsForBookQueryDto>>();
        Assert.NotNull(body);
        Assert.True(body.Items.Count <= 1);
    }

    [Fact]
    public async Task GetReviewsForBook_PageSizeReflectedInResponse()
    {
        var response = await _client.GetAsync("/Reviews/1/all?Paging.PageSize=1");

        var body = await response.Content.ReadFromJsonAsync<PageResult<ListReviewsForBookQueryDto>>();
        Assert.NotNull(body);
        Assert.Equal(1, body.PageSize);
    }

    [Fact]
    public async Task GetReviewsForBook_TotalItemsConsistentAcrossPageSizes()
    {
        var r1 = await (await _client.GetAsync("/Reviews/1/all?Paging.PageSize=1")).Content
            .ReadFromJsonAsync<PageResult<ListReviewsForBookQueryDto>>();
        var r2 = await (await _client.GetAsync("/Reviews/1/all?Paging.PageSize=50")).Content
            .ReadFromJsonAsync<PageResult<ListReviewsForBookQueryDto>>();

        Assert.NotNull(r1);
        Assert.NotNull(r2);
        Assert.Equal(r1.TotalItems, r2.TotalItems);
    }

    [Fact]
    public async Task GetReviewsForBook_MultipleBooks_AllReturnOk()
    {
        var books = new[] { 1, 2, 3 };
        foreach (var bookId in books)
        {
            var response = await _client.GetAsync($"/Reviews/{bookId}/all");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
