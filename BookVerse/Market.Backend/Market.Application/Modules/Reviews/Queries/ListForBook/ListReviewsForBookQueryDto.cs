namespace Market.Application.Modules.Reviews.Queries.ListForBook
{
    public class ListReviewsForBookQueryDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public  ListReviewsForBookQueryDtoUserInfo User { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DatePosted { get; set; }
    }

    public class ListReviewsForBookQueryDtoUserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
