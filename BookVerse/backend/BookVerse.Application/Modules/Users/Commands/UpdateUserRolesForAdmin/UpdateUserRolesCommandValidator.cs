namespace BookVerse.Application.Modules.Users.Commands.UpdateUserRolesForAdmin;

public class UpdateUserRolesCommandValidator : AbstractValidator<UpdateUserRolesCommand>
{
    public UpdateUserRolesCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("User Id must be greater than zero.");
    }
}
