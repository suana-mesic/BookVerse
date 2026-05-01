using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Categories.Commands.Update
{
    public sealed class UpdateCategoryCommandHandler(IAppDbContext context)
        : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var entity = await context.Categories
                .Where(x => x.Id == command.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity is null)
                throw new BookVerseNotFoundException($"Category (ID={command.Id}) not found.");

            // Check for duplicate name (case-insensitive, except for the same ID)
            var exists = await context.Categories
                .AnyAsync(x => x.Id != command.Id && x.Name.ToLower() == command.Name.ToLower(), cancellationToken);

            if (exists)
            {
                throw new BookVerseConflictException("Name already exists.");
            }

            entity.Name = command.Name.Trim();
            entity.IsEnabled = command.isEnabled;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
