namespace BookVerse.Application.Modules.Catalog.Categories.Commands.Status.Enable;

public sealed class EnableCategoryCommandValidator : AbstractValidator<EnableCategoryCommand>
{
    public EnableCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
