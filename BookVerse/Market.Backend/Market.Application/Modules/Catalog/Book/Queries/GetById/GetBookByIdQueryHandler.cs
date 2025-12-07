namespace Market.Application.Modules.Catalog.Book.Queries.GetById;

public class GetBookByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetBookByIdQuery, GetBookByIdQueryDto>
{
    public async Task<GetBookByIdQueryDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {

        var book = await context.Books
            .Where(b => b.Id == request.Id)
            .Select(x => new GetBookByIdQueryDto
            {
                Id = x.Id,
                ISBN = x.ISBN,
                Title = x.Title,
                PublisherId = x.PublisherId,
                PublisherName = x.Publisher.Name,
                BookFormatId = x.BookFormatId,
                BookFormatName = x.BookFormat.Format,
                Price = x.Price,
                Language = x.Language,
                Description = x.Description,
                PageCount = x.PageCount,
                QuantityInStockForOnlineOrders = x.QuantityInStockForOnlineOrders,
                ImageUrl = x.ImageUrl,
                PublishedDate = x.PublishedDate,
                CategoryIds = x.Categories.Select(x => x.Id).ToArray(),
                AuthorIds  = x.Authors.Select(x => x.Id).ToArray()
            }).FirstOrDefaultAsync(cancellationToken);

        if (book == null)
        {
            throw new MarketNotFoundException($"Knjiga sa unesenom vrijednošću Id-a: {request.Id} nije pronađena.");
        }

        return book;
    }
}