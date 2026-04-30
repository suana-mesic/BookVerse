using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Authors.Commands.Delete;
public class DeleteAuthorCommandHandler(IAppDbContext context, IAppCurrentUser appCurrentUser)
  : IRequestHandler<DeleteAuthorCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Authors
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (author is null)
            throw new BookVerseNotFoundException("Author not found.");

        author.IsDeleted = true; // Soft delete
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
