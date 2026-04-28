using Market.Application.Common.Interfaces;

namespace Market.Application.Modules.Catalog.Book.Queries.GetById;

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
                QuantityInStockForOnlineOrders = x.QuantityInStockForOnlineOrders,
                ImageUrl = x.ImageUrl,
                PublishedDate = x.PublishedDate,
                CategoryIds = x.Categories.Select(x => x.Id).Distinct().ToArray(),
                AuthorIds = x.Authors.Select(x => x.Id).Distinct().ToArray()
            }).FirstOrDefaultAsync(cancellationToken);

        if (book == null)
            throw new MarketNotFoundException($"Knjiga sa unesenom vrijednošću Id-a: {request.Id} nije pronađena.");

        if (!string.IsNullOrWhiteSpace(request.Language) && request.Language != "bs")
        {
            //paralelno izvršavanje više asinhronih zahtjeva odjednom.
            //pokreće sve prijevode istovremeno
            var results = await Task.WhenAll(
                translationService.Translate(book.Title, request.Language),
                translationService.Translate(book.Description, request.Language),
                translationService.Translate(book.PublisherName, request.Language),
                translationService.Translate(book.BookFormatName, request.Language),
                translationService.Translate(book.Language, request.Language)
            );
            book.Title = results[0];
            book.Description = results[1];
            book.PublisherName = results[2];
            book.BookFormatName = results[3];
            book.Language = results[4];
        }

        return book;
    }
}
