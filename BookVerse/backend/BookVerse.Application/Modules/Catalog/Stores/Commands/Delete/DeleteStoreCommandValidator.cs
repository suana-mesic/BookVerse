namespace BookVerse.Application.Modules.Catalog.Stores.Commands.Delete;

public class DeleteStoreCommandValidator : AbstractValidator<DeleteStoreCommand>
{
    public DeleteStoreCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
