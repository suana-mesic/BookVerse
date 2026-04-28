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
        bool languageExists = await context.Languages.AnyAsync(x => x.Id == request.LanguageId);


        if (exists)
            throw new MarketConflictException("Knjiga sa unesenim ISBN-om već posotji.");

        if(!publisherExists)
            throw new MarketConflictException("Izdavač sa unesenom ID vrijednošću ne postoji.");

        if (!formatExists)
            throw new MarketConflictException("Format knjige sa unesenom ID vrijednošću ne postoji.");

        if (!languageExists)
            throw new MarketConflictException("Jezik sa unesenom ID vrijednošću ne postoji.");

        var book = new Books
        {
            ISBN = request.ISBN,
            Title = request.Title,
            PublisherId = request.PublisherId,
            BookFormatId = request.BookFormatId,
            Price = request.Price,
            LanguageId = request.LanguageId,
            Description = request.Description??"",
            PageCount = request.PageCount,
            QuantityInStockForOnlineOrders = request.QuantityInStockForOnlineOrders??0,
            ImageUrl = request.ImageUrl??"",
            PublishedDate = request.PublishedDate,
            IsDeleted = false,
            CreatedAtUtc = DateTime.UtcNow
        };

        context.Books.Add(book);

        foreach (var auId in request.AuthorIds)
        {
            var authorObj = await context.Authors.FindAsync(auId);
            if (authorObj != null)
                book.Authors.Add(authorObj);
            else
                throw new MarketNotFoundException("Autor ne postoji");
        }

        foreach (var catId in request.CategoryIds)
        {
            var categoryObj = await context.Categories.FindAsync(catId);
            if (categoryObj != null)
                book.Categories.Add(categoryObj);
            else
                throw new MarketNotFoundException("Kategorija ne postoji");
        }
        await context.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}