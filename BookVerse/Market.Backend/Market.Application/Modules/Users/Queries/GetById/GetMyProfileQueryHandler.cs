using Market.Application.Modules.Users.Queries.GetById;

namespace Market.Application.Modules.Users.Queries.GetMyProfile;

public sealed class GetMyProfileQueryHandler(
    IAppDbContext ctx,
    IAppCurrentUser currentUser)
    : IRequestHandler<GetMyProfileQuery, GetMyProfileQueryDto>
{
    public async Task<GetMyProfileQueryDto> Handle(GetMyProfileQuery request, CancellationToken ct)
    {
        var user = await ctx.Users
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == currentUser.UserId && x.IsEnabled && !x.IsDeleted, ct)
            ?? throw new MarketNotFoundException("Korisnik nije pronađen.");

        return new GetMyProfileQueryDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Line1 = user.Address?.Line1 ?? "",
            Line2 = user.Address?.Line2,
            City = user.Address?.City ?? "",
            Country = user.Address?.Country ?? "",
            TwoFactorEnabled = user.TwoFactorEnabled
        };
    }
}