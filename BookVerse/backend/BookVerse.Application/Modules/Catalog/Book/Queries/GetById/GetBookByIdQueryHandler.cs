using BookVerse.Application.Common.Interfaces;

namespace BookVerse.Application.Modules.Catalog.Book.Queries.GetById;

public class GetBookByIdQueryHandler(IAppDbContext context, ITranslationService translationService)
    : IRequestHandler<GetBookByIdQuery, GetBookByIdQueryDto>
{
    public async Task<GetBookByIdQueryDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await context.Books
            .Where(b => b.Id == request.Id)
            .Select(x => new GetBookByIdQueryDto
            {
                Id = x.Id,
                Isbn = x.ISBN,
                Title = x.Title,
                PublisherId = x.PublisherId,
                PublisherName = x.Publisher.Name,
                BookFormatId = x.BookFormatId,
                BookFormatName = x.BookFormat.Format,
                Price = x.Price,
                LanguageId = x.LanguageId,
                Language = x.Language.Name,
                Description = x.Description,
                PageCount = x.PageCount,
                // QuantityInStockForOnlineOrders is deliberately NOT projected - the by-id
                // endpoint is anonymous, same security reasoning as in ListBooksQueryHandler.
                ImageUrl = x.ImageUrl,
                PublishedDate = x.PublishedDate,
                CategoryIds = x.Categories.Select(x => x.Id).Distinct().ToArray(),
                AuthorIds = x.Authors.Select(x => x.Id).Distinct().ToArray()
            })
            // Same reason as in ListBooksQueryHandler: this projection pulls two collection
            // navigations (Categories, Authors), and without AsSplitQuery EF Core warns about
            // the cartesian product and slows down the response.
            .AsSplitQuery()
            .FirstOrDefaultAsync(cancellationToken);

        if (book == null)
            throw new BookVerseNotFoundException($"Book with entered ID value: {request.Id} not found.");

        if (!string.IsNullOrWhiteSpace(request.Language) && request.Language != "bs")
        {
            //parallel execution of multiple async requests at once.
            //starts all translations simultaneously
            var results = await Task.WhenAll(
                translationService.Translate(book.Description, request.Language),
                translationService.Translate(book.BookFormatName, request.Language),
                translationService.Translate(book.Language, request.Language)
            );
            book.Description = results[0];
            book.BookFormatName = results[1];
            book.Language = results[2];
        }

        return book;
    }
}
