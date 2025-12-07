using Market.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading;

namespace Market.Application.Modules.Catalog.Book.Commands.Update;

public sealed class UpdateBookCommandHandler(IAppDbContext context)
            : IRequestHandler<UpdateBookCommand, Unit>
{
    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken ct)
    {

        var book = await context.Books
            .Include(x=>x.Authors)
            .Include(x=>x.Categories)
            .Include(x=>x.BookFormat)
            .Include(x=>x.Publisher)
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(ct);

        if (book is null)
            throw new MarketNotFoundException($"Knjiga (ID={request.Id}) nije pronađena.");

        await ValidateBusinessRules(request, book, ct);

        if (!string.IsNullOrWhiteSpace(request.ISBN))
            book.ISBN = request.ISBN;
        if (!string.IsNullOrWhiteSpace(request.Title))
            book.Title = request.Title;
        if (request.PublisherId != null)
            book.PublisherId = request.PublisherId.Value;
        if (request.BookFormatId.HasValue)
            book.BookFormatId = request.BookFormatId.Value;
        if (request.Price.HasValue)
            book.Price = request.Price.Value;
        if (!string.IsNullOrEmpty(request.Language))
            book.Language = request.Language;
        if (!string.IsNullOrEmpty(request.Description))
            book.Description = request.Description;
        if (request.PageCount.HasValue)
            book.PageCount = request.PageCount.Value;
        if (request.QuantityInStockForOnlineOrders.HasValue)
            book.QuantityInStockForOnlineOrders = request.QuantityInStockForOnlineOrders.Value;
        if (!string.IsNullOrEmpty(request.ImageUrl))
            book.ImageUrl = request.ImageUrl;
        if (request.PublishedDate.HasValue)
            book.PublishedDate = request.PublishedDate.Value;
        if (request.AuthorIds!= null && request.AuthorIds.Length != 0)
        {
            book.Authors.Clear();
            foreach (var auId in request.AuthorIds)
            {
                var authorObj = await context.Authors.FindAsync(auId);
                book.Authors.Add(authorObj);
            }
        }
        if (request.CategoryIds != null && request.CategoryIds.Length != 0)
        {
            book.Categories.Clear();
            foreach (var catId in request.CategoryIds)
            {
                var categoryObj = await context.Categories.FindAsync(catId);
                book.Categories.Add(categoryObj);
            }
        }

        book.ModifiedAtUtc = DateTime.UtcNow;

        await context.SaveChangesAsync(ct);

        return Unit.Value;
    }

    private async Task ValidateBusinessRules(UpdateBookCommand request, Books existingBook, CancellationToken ct)
    {
        // If trying to assign an ISBN to a existingBook, but that ISBN has already been assigned to another book
        var exists = await context.Books.AnyAsync(x => x.Id != request.Id && x.ISBN.ToLower() == request.ISBN.ToLower(), ct);

        if (exists)
            throw new MarketConflictException("ISBN already exists.");

        if (request.PublisherId.HasValue && request.PublisherId.Value != existingBook.PublisherId)
        {
            var publisherExists = await context.Publishers.AnyAsync(x => x.Id == request.PublisherId.Value, ct);

            if (!publisherExists)
            {
                throw new ValidationException($"Publisher sa ID {request.PublisherId} ne postoji");
            }
        }
        // Provjera postojanja book format-a SAMO ako se format mijenja
        if (request.BookFormatId.HasValue && request.BookFormatId.Value != existingBook.BookFormatId)
        {
            var formatExists = await context.BookFormats
                .AnyAsync(f => f.Id == request.BookFormatId.Value && !f.IsDeleted, ct);

            if (!formatExists)
            {
                throw new ValidationException($"DatePosted format sa ID {request.BookFormatId} ne postoji");
            }
        }
    }
}
