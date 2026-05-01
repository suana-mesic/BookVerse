namespace BookVerse.Application.Modules.Users.Queries.ListForAdmin;

public class ListUsersQueryHandler(IAppDbContext context)
    : IRequestHandler<ListUsersQuery, PageResult<ListUsersQueryDto>>
{
    public async Task<PageResult<ListUsersQueryDto>> Handle(ListUsersQuery request, CancellationToken ct)
    {
        var q = context.Users
            .AsNoTracking()
            .Where(x => !x.IsDeleted);

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            q = q.Where(x =>
                (x.FirstName + " " + x.LastName).Contains(request.Search) ||
                x.Email.Contains(request.Search));
        }

        var projectedQuery = q
            .OrderBy(x => x.FirstName)
            .Select(x => new ListUsersQueryDto
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName,
                Email = x.Email,
                IsAdmin = x.IsAdmin,
                IsManager = x.IsManager,
                IsEmployee = x.IsEmployee,
                IsEnabled = x.IsEnabled
            });

        return await PageResult<ListUsersQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}