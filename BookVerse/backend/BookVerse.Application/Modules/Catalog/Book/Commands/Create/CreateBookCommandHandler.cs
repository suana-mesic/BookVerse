namespace BookVerse.Application.Modules.Catalog.Book.Commands.Create;

public class CreateBookCommandHandler(IAppDbContext context, TimeProvider time)
    : IRequestHandler<CreateBookCommand, int>
{
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var cleanIsbn = request.ISBN.Replace("-", "");
        bool exists = await context.Books.AnyAsync(x => x.ISBN.Replace("-", "") == cleanIsbn, cancellationToken);
        bool publisherExists = await context.Publishers.AnyAsync(x => x.Id == request.PublisherId, cancellationToken);
        bool formatExists = await context.BookFormats.AnyAsync(x => x.Id == request.BookFormatId, cancellationToken);
        bool languageExists = await context.Languages.AnyAsync(x => x.Id == request.LanguageId, cancellationToken);


        if (exists)
            throw new BookVerseConflictException("A book with the provided ISBN already exists.");

        if(!publisherExists)
            throw new BookVerseConflictException("A publisher with the provided ID does not exist.");

        if (!formatExists)
            throw new BookVerseConflictException("A book format with the provided ID does not exist.");

        if (!languageExists)
            throw new BookVerseConflictException("A language with the provided ID does not exist.");

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
            // TimeProvider so unit tests can pin CreatedAtUtc deterministically.
            CreatedAtUtc = time.GetUtcNow().UtcDateTime
        };

        context.Books.Add(book);

        foreach (var auId in request.AuthorIds)
        {
            var authorObj = await context.Authors.FindAsync(auId);
            if (authorObj != null)
                book.Authors.Add(authorObj);
            else
                throw new BookVerseNotFoundException("Author does not exist.");
        }

        foreach (var catId in request.CategoryIds)
        {
            var categoryObj = await context.Categories.FindAsync(catId);
            if (categoryObj != null)
                book.Categories.Add(categoryObj);
            else
                throw new BookVerseNotFoundException("Category does not exist.");
        }
        await context.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}
