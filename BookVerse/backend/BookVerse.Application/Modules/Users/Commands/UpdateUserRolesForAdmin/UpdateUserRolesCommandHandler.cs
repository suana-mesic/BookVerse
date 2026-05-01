// UpdateUserRolesCommandHandler.cs
using BookVerse.Application.Modules.Users.Commands.UpdateUserRolesForAdmin;

public class UpdateUserRolesCommandHandler(IAppDbContext context)
    : IRequestHandler<UpdateUserRolesCommand>
{
    public async Task Handle(UpdateUserRolesCommand request, CancellationToken ct)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, ct)
            ?? throw new BookVerseNotFoundException($"User with ID {request.Id} not found.");

        // Update roles
        user.IsAdmin = request.IsAdmin;
        user.IsManager = request.IsManager;
        user.IsEmployee = request.IsEmployee;
        user.IsEnabled = request.IsEnabled;

        // Invalidate the token — the user must receive a new token with the updated roles
        user.TokenVersion++;

        await context.SaveChangesAsync(ct);
    }
}