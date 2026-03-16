namespace Market.Application.Modules.Reviews.Queries.ListForBook
{
    public class ListReviewsForBookQuery:BasePagedQuery<ListReviewsForBookQueryDto>
    {
        public string? Search { get; set; }
        [JsonIgnore]
        public int BookId { get; set; }

    }
}
