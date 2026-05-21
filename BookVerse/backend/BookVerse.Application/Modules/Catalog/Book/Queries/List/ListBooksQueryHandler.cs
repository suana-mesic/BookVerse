using BookVerse.Application.Common.Interfaces;
using BookVerse.Application.Modules.Catalog.Authors.Queries;
using BookVerse.Application.Modules.Catalog.Authors.Queries.List;
using BookVerse.Application.Modules.Catalog.Categories.Queries.List;

namespace BookVerse.Application.Modules.Catalog.Book.Queries.List;
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
             x.Publisher.Name.Contains(request.Search) ||
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
                LanguageId = x.LanguageId,
                Language = x.Language.Name,
                Description = x.Description,
                PageCount = x.PageCount,
                // QuantityInStockForOnlineOrders and IsDeleted are deliberately NOT projected
                // here - this endpoint is public, so exposing them would leak inventory levels
                // and internal soft-delete state to anyone scraping the API.
                ImageUrl = x.ImageUrl,
                PublishedDate = x.PublishedDate,
            })
            // AsSplitQuery turns the one Cartesian SQL (book * authors * categories) into three
            // smaller queries: one for the page of books, one for the authors of those books,
            // one for the categories. Without this, EF Core warns about the cartesian explosion
            // and the response slows down as soon as books have a few authors and categories.
            // CountAsync inside PageResult is unaffected - it does not load collections.
            .AsSplitQuery();

        return await PageResult<ListBooksQueryDto>.FromQueryableAsync(
        query: projectedQuery,
        paging: request.Paging,
        ct:ct,
        postProcess: async items =>
        {
            if (string.IsNullOrWhiteSpace(request.Language) ||
                request.Language == "bs")
                return;

            // Process books one after another instead of all at once.
            // Old code did Task.WhenAll over every book AND Task.WhenAll over every
            // field inside each book, which on page size 20 produced ~100+ parallel
            // HTTP calls to Google. That is the exact thing that gets the server IP
            // throttled or blocked.
            //
            // Now: outer loop is sequential, but the 4 fields of a single book are
            // still translated in parallel because they are independent. That caps
            // concurrent Google calls at about 4-5. Combined with the cache inside
            // TranslationService, repeated strings (like common publisher names,
            // "Paperback", "English") only hit the network once.
            foreach (var book in items)
            {
                if (request.LookupsOnly)
                {
                    book.BookFormatName = await translationService.Translate(book.BookFormatName, request.Language, ct);
                }
                else
                {
                    var mainResults = await Task.WhenAll(
                        translationService.Translate(book.Description, request.Language, ct),
                        translationService.Translate(book.PublisherName, request.Language, ct),
                        translationService.Translate(book.BookFormatName, request.Language, ct),
                        translationService.Translate(book.Language, request.Language, ct)
                    );
                    book.Description = mainResults[0];
                    book.PublisherName = mainResults[1];
                    book.BookFormatName = mainResults[2];
                    book.Language = mainResults[3];
                }

                // Categories of a single book are also translated in parallel - usually
                // a small handful, and the cache makes second-page requests nearly free.
                await Task.WhenAll(book.Categories.Select(async c =>
                {
                    c.Name = await translationService.Translate(c.Name, request.Language, ct);
                }));
            }
        });
    }
}
