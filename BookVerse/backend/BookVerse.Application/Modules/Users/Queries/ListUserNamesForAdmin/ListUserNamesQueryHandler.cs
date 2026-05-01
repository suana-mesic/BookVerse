namespace BookVerse.Application.Modules.Users.Queries.ListForAdmin;

public class ListUserNamesQueryHandler(IAppDbContext context)
    : IRequestHandler<ListUserNamesQuery, List<ListUserNamesQueryDto>>
{
    public async Task<List<ListUserNamesQueryDto>> Handle(ListUserNamesQuery request, CancellationToken ct)
    {
        return await context.Users
            .Where(x => !x.IsDeleted)
            .Select(x => new ListUserNamesQueryDto
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName,
            })
            .ToListAsync(ct);
    }
}