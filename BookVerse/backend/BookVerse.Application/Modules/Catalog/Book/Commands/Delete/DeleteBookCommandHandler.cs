using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Book.Commands.Delete;
public class DeleteBookCommandHandler(IAppDbContext context,IAppCurrentUser appCurrentUser)
:IRequestHandler<DeleteBookCommand,Unit>{
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (book is null)
            throw new BookVerseNotFoundException("Book not found.");

        book.IsDeleted = true; // Soft delete
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
