// GetUserByIdQueryHandler.cs
using Market.Application.Modules.Users.Queries.GetByIdForAdmin;

public class GetUserByIdQueryHandler(IAppDbContext context)
    : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryDto>
{
    public async Task<GetUserByIdQueryDto> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        var user = await context.Users
            .Where(x => x.Id == request.Id && !x.IsDeleted)
            .Select(x => new GetUserByIdQueryDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                IsAdmin = x.IsAdmin,
                IsManager = x.IsManager,
                IsEmployee = x.IsEmployee,
                IsEnabled = x.IsEnabled
            })
            .FirstOrDefaultAsync(ct)
            ?? throw new MarketNotFoundException($"Korisnik sa ID {request.Id} nije pronađen.");

        return user;
    }
}