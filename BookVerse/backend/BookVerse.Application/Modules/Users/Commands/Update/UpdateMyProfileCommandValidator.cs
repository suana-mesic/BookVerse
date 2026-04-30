namespace BookVerse.Application.Modules.Users.Commands.UpdateMyProfile;

public sealed class UpdateMyProfileCommandValidator : AbstractValidator<UpdateMyProfileCommand>
{
    public UpdateMyProfileCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(100).WithMessage("First name can be up to 100 characters long.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(100).WithMessage("Last name can be up to 100 characters long.");

        RuleFor(x => x.Line1)
            .NotEmpty().WithMessage("Address line 1 is required.")
            .MaximumLength(200).WithMessage("Address line 1 can be up to 200 characters long.");

        RuleFor(x => x.Line2)
            .MaximumLength(200).WithMessage("Address line 2 can be up to 200 characters long.")
            .When(x => !string.IsNullOrWhiteSpace(x.Line2));

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(100).WithMessage("City can be up to 100 characters long.");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(100).WithMessage("Country can be up to 100 characters long.");
    }
}
