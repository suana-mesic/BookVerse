using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Authors.Commands.Update;
public sealed class UpdateAuthorCommandHandler(IAppDbContext ctx)
        : IRequestHandler<UpdateAuthorCommand, Unit>
{
    public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken ct)
    {
        var entity = await ctx.Authors
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(ct);

        if(entity is null)
            throw new MarketNotFoundException($"Autor (ID={request.Id}) nije pronađen.");

        entity.FirstName = request.FirstName is not null ? request.FirstName.Trim() : entity.FirstName;
        entity.LastName = request.LastName is not null ? request.LastName.Trim() : entity.LastName;
        entity.Biography = request.Biography is not null ? request.Biography.Trim() : entity.Biography;
        entity.Country = request.Country is not null ? request.Country.Trim() : entity.Country;

        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}