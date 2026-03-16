namespace Market.Application.Modules.Reviews.Queries.ListForBook
{
    public class ListReviewsForBookQueryHandler(IAppDbContext context) : IRequestHandler<ListReviewsForBookQuery, PageResult<ListReviewsForBookQueryDto>>
    {
        public async Task<PageResult<ListReviewsForBookQueryDto>> Handle(ListReviewsForBookQuery request, CancellationToken ct)
        {
            var query = context.Reviews
                .Include(x=>x.User)
                .Where(x=>x.BookId == request.BookId)
                .Where(x => string.IsNullOrWhiteSpace(request.Search) || x.Comment.ToLower().Contains(request.Search))
                .Select(x => new ListReviewsForBookQueryDto
                {
                    BookId = x.BookId,
                    UserId = x.UserId,
                    User = new ListReviewsForBookQueryDtoUserInfo
                    {
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName
                    },
                    Rating = x.Rating,
                    Comment = x.Comment,
                    DatePosted = x.DatePosted
                });

            return await PageResult<ListReviewsForBookQueryDto>.FromQueryableAsync(query, request.Paging, ct);
        }
    }
}
