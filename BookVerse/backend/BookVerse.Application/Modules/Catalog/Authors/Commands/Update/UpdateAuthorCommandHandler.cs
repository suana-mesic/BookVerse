using BookVerse.Domain.Entities.Catalog;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Authors.Commands.Update;
public sealed class UpdateAuthorCommandHandler(IAppDbContext ctx)
        : IRequestHandler<UpdateAuthorCommand, Unit>
{
    public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken ct)
    {
        var entity = await ctx.Authors
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(ct);

        if(entity is null)
            throw new BookVerseNotFoundException($"Author (ID={request.Id}) was not found.");


        if (!string.IsNullOrWhiteSpace(request.FirstName))
            entity.FirstName = request.FirstName;
        if (!string.IsNullOrWhiteSpace(request.LastName))
            entity.LastName= request.LastName;
        if (!string.IsNullOrWhiteSpace(request.Biography))
            entity.Biography= request.Biography;
        if (!string.IsNullOrWhiteSpace(request.Country))
            entity.Country= request.Country;

        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
