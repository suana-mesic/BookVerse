using Market.Application.Modules.Book.Queries.List;
using Market.Application.Modules.Catalog.ProductCategories.Queries.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Book.Queries.List;
public sealed class ListBooksQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListBooksQuery, PageResult<ListBooksQueryDto>>
{
    public async Task<PageResult<ListBooksQueryDto>> Handle(
        ListBooksQuery request, CancellationToken ct)
    {

        var q = ctx.Books.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            q = q.Where(x => x.Title.Contains(request.Search));
        }

        var projectedQuery = q.OrderBy(x => x.Title)
            .Select(x => new ListBooksQueryDto
            {
                Id = x.Id,
                ISBN = x.ISBN,
                BookTitle = x.Title,
                PublisherName = x.Publisher.Name,
                BookFormatName = x.BookFormat.Format,
                Price = x.Price,
                Language = x.Language,
                Description = x.Description,
                PageCount = x.PageCount,
                QuantityInStockForOnlineOrders = x.QuantityInStockForOnlineOrders,
                ImageUrl = x.ImageUrl,
                PublishedDate = x.PublishedDate,
            });

        return await PageResult<ListBooksQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}
