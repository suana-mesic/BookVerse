namespace Market.Application.Modules.Users.Queries.List
{
    public class ListUsersQueryHandler(IAppDbContext context) : IRequestHandler<ListUsersQuery, List<ListUsersQueryDto>>
    {
        public async Task<List<ListUsersQueryDto>> Handle(ListUsersQuery request, CancellationToken ct)
        {
            var q = context.Users;

            var users = await context.Users
               .Where(x => !x.IsDeleted)
               .Select(x => new ListUsersQueryDto
               {
                   Id = x.Id,
                   FullName = x.FirstName + " " + x.LastName,
               })
               .ToListAsync(ct);
            return users;
        }
    }
}
