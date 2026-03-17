// UpdateUserRolesCommandHandler.cs
using Market.Application.Modules.Users.Commands.UpdateUserRolesForAdmin;

public class UpdateUserRolesCommandHandler(IAppDbContext context)
    : IRequestHandler<UpdateUserRolesCommand>
{
    public async Task Handle(UpdateUserRolesCommand request, CancellationToken ct)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, ct)
            ?? throw new MarketNotFoundException($"Korisnik sa ID {request.Id} nije pronađen.");

        // Ažuriramo role
        user.IsAdmin = request.IsAdmin;
        user.IsManager = request.IsManager;
        user.IsEmployee = request.IsEmployee;
        user.IsEnabled = request.IsEnabled;

        // Invalidiramo token — korisnik mora dobiti novi token sa novim rolama
        user.TokenVersion++;

        await context.SaveChangesAsync(ct);
    }
}