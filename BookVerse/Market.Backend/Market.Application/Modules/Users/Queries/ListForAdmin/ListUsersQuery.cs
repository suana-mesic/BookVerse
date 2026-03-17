namespace Market.Application.Modules.Users.Queries.ListForAdmin;

public sealed class ListUsersQuery : BasePagedQuery<ListUsersQueryDto>
{
    public string? Search { get; init; }
}