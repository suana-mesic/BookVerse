namespace Market.Application.Modules.Users.Commands.UpdateMyProfile;

public sealed class UpdateMyProfileCommandHandler(
    IAppDbContext ctx,
    IAppCurrentUser currentUser)
    : IRequestHandler<UpdateMyProfileCommand>
{
    public async Task Handle(UpdateMyProfileCommand request, CancellationToken ct)
    {
        var user = await ctx.Users
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == currentUser.UserId && x.IsEnabled && !x.IsDeleted, ct)
            ?? throw new MarketNotFoundException("Korisnik nije pronađen.");

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.TwoFactorEnabled = request.TwoFactorEnabled;

        if (user.Address != null)
        {
            user.Address.Line1 = request.Line1;
            user.Address.Line2 = request.Line2;
            user.Address.City = request.City;
            user.Address.Country = request.Country;
        }

        await ctx.SaveChangesAsync(ct);
    }
}