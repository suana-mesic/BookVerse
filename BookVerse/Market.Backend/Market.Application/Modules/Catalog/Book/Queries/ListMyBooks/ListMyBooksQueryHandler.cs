using System.Linq.Expressions;
using Market.Application.Common.Interfaces;
using Market.Domain.Entities.Shopping;

namespace Market.Application.Modules.Catalog.Book.Queries.ListMyBooks
{
    public class ListMyBooksQueryHandler(IAppDbContext context, IAppCurrentUser currentUser, ITranslationService translationService)
        : IRequestHandler<ListMyBooksQuery, PageResult<ListMyBooksQueryDto>>
    {
        public async Task<PageResult<ListMyBooksQueryDto>> Handle(
            ListMyBooksQuery request, CancellationToken ct)

        {
            var isForeignLang = !string.IsNullOrWhiteSpace(request.Language) && request.Language != "bs";

            var baseQuery = context.Books
                .Include(x => x.Categories)
                .Include(x => x.OrderItems)
                .Where(x => x.OrderItems.Any(oi => oi.Order.UserId == currentUser.UserId && (oi.Order.OrderStatus.StatusName == OrderStatusType.Paid || oi.Order.OrderStatus.StatusName == OrderStatusType.Packed || oi.Order.OrderStatus.StatusName == OrderStatusType.Shipped)))
                .Where(x => !x.IsDeleted)
                .Where(x => !request.CategoryIds.Any() || request.CategoryIds.All(cid => x.Categories.Any(c => c.Id == cid)));

            Expression<Func<Books, ListMyBooksQueryDto>> projection = x => new ListMyBooksQueryDto
            {
                BookId = x.Id,
                Title = x.Title,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Language = x.Language.Name,
                Description = x.Description,
                Categories = x.Categories.Select(c => new ListBooksQueryDtoCategory
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
                UserReview = context.Reviews
                    .Where(r => r.BookId == x.Id && r.UserId == currentUser.UserId && !r.IsDeleted)
                    .Select(r => new ListReviewsQueryDtoCategory
                    {
                        Rating = r.Rating,
                        Comment = r.Comment,
                        CreatedAt = r.DatePosted,
                        UpdatedAt = r.UpdatedAt
                    })
                    .FirstOrDefault()
            };

            if (!isForeignLang)
            {
                var query = baseQuery
                    .Where(x => string.IsNullOrEmpty(request.Search) || x.Title.ToLower().Contains(request.Search.ToLower()))
                    .Select(projection)
                    .OrderByDescending(x => x.BookId);

                return await PageResult<ListMyBooksQueryDto>.FromQueryableAsync(query, request.Paging, ct);
            }

            var allItems = await baseQuery
                .Select(projection)
                .OrderByDescending(x => x.BookId)
                .ToListAsync(ct);

            await Task.WhenAll(allItems.Select(async book =>
            {
                var results = await Task.WhenAll(
                    translationService.Translate(book.Title ?? string.Empty, request.Language!),
                    translationService.Translate(book.Description ?? string.Empty, request.Language!),
                    translationService.Translate(book.Language, request.Language!)
                );
                book.Title = results[0];
                book.Description = results[1];
                book.Language = results[2];

                await Task.WhenAll(book.Categories.Select(async c =>
                {
                    c.Name = await translationService.Translate(c.Name, request.Language!);
                }));
            }));

            var filtered = string.IsNullOrWhiteSpace(request.Search)
                ? allItems
                : allItems.Where(b => (b.Title ?? string.Empty).ToLower().Contains(request.Search.ToLower())).ToList();

            var total = filtered.Count;
            var pageItems = filtered
                .Skip(request.Paging.SkipCount)
                .Take(request.Paging.PageSize)
                .ToList();

            return new PageResult<ListMyBooksQueryDto>
            {
                Items = pageItems,
                PageSize = request.Paging.PageSize,
                CurrentPage = request.Paging.Page,
                IncludedTotal = true,
                TotalItems = total,
                TotalPages = (int)Math.Ceiling(total / (double)request.Paging.PageSize)
            };
        }
    }

}