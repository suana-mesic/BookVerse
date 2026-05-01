namespace BookVerse.Application.Modules.Catalog.Categories.Commands.Status.Disable;

public sealed class DisableCategoryCommandValidator : AbstractValidator<DisableCategoryCommand>
{
    public DisableCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
