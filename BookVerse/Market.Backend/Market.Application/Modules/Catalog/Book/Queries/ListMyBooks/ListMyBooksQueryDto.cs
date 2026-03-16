namespace Market.Application.Modules.Catalog.Book.Queries.ListMyBooks
{
    public class ListMyBooksQueryDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; } = string.Empty;
        public string? Description { get; set; }

        public List<ListBooksQueryDtoCategory> Categories { get; set; } = new();

        // Podaci o recenziji korisnika (null ako ne postoji)
        public ListReviewsQueryDtoCategory? UserReview { get; set; }
    }
    public class ListBooksQueryDtoCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class ListReviewsQueryDtoCategory
    {
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
