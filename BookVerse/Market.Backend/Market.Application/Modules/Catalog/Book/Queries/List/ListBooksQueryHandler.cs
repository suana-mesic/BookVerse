using Market.Application.Modules.Catalog.Authors.Queries;
using Market.Application.Modules.Catalog.Categories.Queries.List;
using Market.Application.Modules.Catalog.ProductCategories.Queries.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Book.Queries.List;
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
                ISBN = x.ISBN,
                Title = x.Title,
                PublisherName = x.Publisher.Name,
                Authors = x.Authors.Select(a => new ListAuthorsQueryDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                }).ToList(),
                Categories = x.Categories.Select(c => new ListCategoriesQueryDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
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
