using System.Linq.Expressions;
using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Modules.Catalog.Book.Queries.ListMyBooks
{
    public class ListMyBooksQueryHandler(IAppDbContext context, IAppCurrentUser currentUser, ITranslationService translationService)
        : IRequestHandler<ListMyBooksQuery, PageResult<ListMyBooksQueryDto>>
    {
        public async Task<PageResult<ListMyBooksQueryDto>> Handle(
            ListMyBooksQuery request, CancellationToken ct)

        {
            var query = context.Books
                .Include(x => x.Categories)
                .Include(x => x.OrderItems)
                .Where(x => x.OrderItems.Any(oi => oi.Order.UserId == currentUser.UserId && (oi.Order.OrderStatus.StatusName == OrderStatusType.Paid || oi.Order.OrderStatus.StatusName == OrderStatusType.Packed || oi.Order.OrderStatus.StatusName == OrderStatusType.Shipped)))
                .Where(x => !x.IsDeleted)
                .Where(x => !request.CategoryIds.Any() || request.CategoryIds.All(cid => x.Categories.Any(c => c.Id == cid)))
                .Where(x => string.IsNullOrEmpty(request.Search) || x.Title.ToLower().Contains(request.Search.ToLower()))
                .Select(x => new ListMyBooksQueryDto
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
                })
                .OrderByDescending(x => x.BookId);

            return await PageResult<ListMyBooksQueryDto>.FromQueryableAsync(query, request.Paging, ct,
                postProcess: async items =>
                {
                    if (string.IsNullOrWhiteSpace(request.Language) || request.Language == "bs")
                        return;

                    await Task.WhenAll(items.Select(async book =>
                    {
                        var results = await Task.WhenAll(
                            translationService.Translate(book.Description ?? string.Empty, request.Language!),
                            translationService.Translate(book.Language, request.Language!)
                        );
                        book.Description = results[0];
                        book.Language = results[1];

                        await Task.WhenAll(book.Categories.Select(async c =>
                        {
                            c.Name = await translationService.Translate(c.Name, request.Language!);
                        }));
                    }));
                });
        }
    }

}