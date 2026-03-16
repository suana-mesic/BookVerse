//using Market.Application.Modules.Reviews.Queries.GetById;
//using Market.Application.Modules.Reviews.Queries.List;

//namespace Market.Application.Modules.Reviews.Queries.List;

//public sealed class ListReviewsQueryHandler(IAppDbContext ctx)
//        : IRequestHandler<ListReviewsQuery, PageResult<ListReviewsQueryDto>>
//{
//    public async Task<PageResult<ListReviewsQueryDto>> Handle(
//        ListReviewsQuery request, CancellationToken ct)
//    {
//        var q = ctx.Reviews.AsNoTracking();

//        q = q
//            .Where(x => string.IsNullOrWhiteSpace(request.UserFirstName) || x.User.FirstName.ToLower().Contains(request.UserFirstName.ToLower()))
//            .Where(x => string.IsNullOrWhiteSpace(request.BookTitle) || x.Book.Title.ToLower().Contains(request.BookTitle.ToLower()))
//            .Where(x => !request.Rating.HasValue || x.Rating == request.Rating)
//            .Where(x => string.IsNullOrWhiteSpace(request.Comment) || x.Comment.ToLower().Contains(request.Comment.ToLower()))
//            .Where(x => !request.DateCreatedFrom.HasValue || x.DatePosted >= request.DateCreatedFrom)
//            .Where(x => !request.DateCreatedTo.HasValue || x.DatePosted <= request.DateCreatedTo);

//        var query = q.OrderBy(x => x.DatePosted).Select(x =>
//            new ListReviewsQueryDto
//            {
//                Rating = x.Rating,
//                Comment = x.Comment,
//                CreatedAtUtc = x.DatePosted,
//                Book = new GetReviewsByIdQueryBookDto
//                {
//                    ISBN = x.Book.ISBN,
//                    Title = x.Book.Title
//                },
//                User = new GetReviewsByIdQueryUserDto
//                {
//                    FirstName = x.User.FirstName,
//                    LastName = x.User.LastName
//                }
//            });

//        return await PageResult<ListReviewsQueryDto>.FromQueryableAsync(query, request.Paging, ct);
//    }
//}
