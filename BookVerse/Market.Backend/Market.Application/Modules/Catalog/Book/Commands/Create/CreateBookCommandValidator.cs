using Market.Application.Modules.Catalog.Book.Commands.Create;

public sealed class CreateBookCommandValidator
    : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.ISBN).NotEmpty().WithMessage("ISBN je obavezan");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Naslov je obavezan");
        RuleFor(x => x.PublisherId).NotEmpty().WithMessage("PublisherId mora biti veći od 0");


    }
}