using System.Diagnostics.CodeAnalysis;

namespace Market.Application.Modules.Catalog.Book.Commands.Create;

public class CreateBookCommandHandler(IAppDbContext context)
    : IRequestHandler<CreateBookCommand, int>
{
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        bool exists = await context.Books.AnyAsync(x => x.ISBN == request.ISBN);
        bool publisherExists = await context.Publishers.AnyAsync(x => x.Id == request.PublisherId);
        bool formatExists = await context.BookFormats.AnyAsync(x => x.Id == request.BookFormatId);

        if (exists)
            throw new MarketConflictException("Knjiga sa unesenim ISBN-om već posotji.");

        if(!publisherExists)
            throw new MarketConflictException("Izdavač sa unesenom ID vrijednošću ne postoji.");

        if (!publisherExists)
            throw new MarketConflictException("Format knjige sa unesenom ID vrijednošću ne postoji.");

        var book = new Books
        {
            ISBN = request.ISBN,
            Title = request.Title,
            PublisherId = request.PublisherId, 
            BookFormatId = request.BookFormatId,
            Price = request.Price,
            Language = request.Language,
            Description = request.Description??"",
            PageCount = request.PageCount,
            QuantityInStockForOnlineOrders = request.QuantityInStockForOnlineOrders??0,
            ImageUrl = request.ImageUrl??"",
            PublishedDate = request.PublishedDate,
            IsDeleted = false,
            CreatedAtUtc = DateTime.UtcNow
        };

        context.Books.Add(book);
        await context.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}