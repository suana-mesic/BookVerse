using Market.Application.Common.Interfaces;
using Market.Application.Modules.Catalog.Authors.Queries;
using Market.Application.Modules.Catalog.Authors.Queries.List;
using Market.Application.Modules.Catalog.Categories.Queries.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Book.Queries.List;
public sealed class ListBooksQueryHandler(IAppDbContext context, ITranslationService translationService)
        : IRequestHandler<ListBooksQuery, PageResult<ListBooksQueryDto>>
{
    public async Task<PageResult<ListBooksQueryDto>> Handle(
        ListBooksQuery request, CancellationToken ct)
    {

        var q = context.Books.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            q = q.Where(x => x.Title.Contains(request.Search) ||
             x.Price.ToString().Contains(request.Search) ||
             x.Publisher.Name.Contains(request.Search) ||
             x.BookFormat.Format.Contains(request.Search) ||
             x.QuantityInStockForOnlineOrders.ToString().Contains(request.Search) ||
             x.Categories.Any(c => c.Name == request.Search) ||
             x.Authors.Any(a => (a.FirstName + " " + a.LastName).Contains(request.Search))
            );

        }

        var projectedQuery = q.OrderBy(x => x.Title)
            .Select(x => new ListBooksQueryDto
            {
                Id = x.Id,
                Isbn = x.ISBN,
                Title = x.Title,
                PublisherName = x.Publisher.Name,
                Authors = x.Authors.Distinct().Select(a => new ListAuthorsQueryDto
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
                IsDeleted = x.IsDeleted,
            });

        return await PageResult<ListBooksQueryDto>.FromQueryableAsync(
        query: projectedQuery,
        paging: request.Paging,
        ct:ct,
        postProcess: async items =>
        {
            if (string.IsNullOrWhiteSpace(request.Language) ||
                request.Language == "bs")
                return;

            await Task.WhenAll(items.Select(async book =>
            {
                var mainResults = await Task.WhenAll(
                    translationService.Translate(book.Title, request.Language),
                    translationService.Translate(book.Description, request.Language),
                    translationService.Translate(book.PublisherName, request.Language),
                    translationService.Translate(book.BookFormatName, request.Language),
                    translationService.Translate(book.Language, request.Language)
                );
                book.Title = mainResults[0];
                book.Description = mainResults[1];
                book.PublisherName = mainResults[2];
                book.BookFormatName = mainResults[3];
                book.Language = mainResults[4];

                //await Task.WhenAll(book.Authors.Select(async a =>
                //{
                //    var r = await Task.WhenAll(
                //        translationService.Translate(a.FirstName, request.Language),
                //        translationService.Translate(a.LastName, request.Language)
                //    );
                //    a.FirstName = r[0];
                //    a.LastName = r[1];
                //}));

                await Task.WhenAll(book.Categories.Select(async c =>
                {
                    c.Name = await translationService.Translate(c.Name, request.Language);
                }));
            }));
        });
    }
}
