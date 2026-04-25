namespace Market.Application.Modules.Catalog.Book.Commands.Update;

public sealed class UpdateBookCommandValidator
    : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);

        RuleFor(x => x.ISBN)
            .NotEmpty().WithMessage("ISBN is required.")
            .MaximumLength(Books.Constraints.ISBNMaxLength).WithMessage($"ISBN can be at most {Books.Constraints.ISBNMaxLength} characters long.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(Books.Constraints.TitleMaxLength).WithMessage($"Title can be at most {Books.Constraints.TitleMaxLength} characters long.");

        RuleFor(x => x.Language)
            .NotEmpty().WithMessage("Language is required.")
            .MaximumLength(Books.Constraints.LanguageMaxLength).WithMessage($"Language can be at most {Books.Constraints.LanguageMaxLength} characters long.");

        RuleFor(x => x.PublisherId)
            .NotNull().WithMessage("Publisher is required.")
            .GreaterThan(0).When(x => x.PublisherId.HasValue);

        RuleFor(x => x.BookFormatId)
            .NotNull().WithMessage("Book format is required.")
            .GreaterThan(0).When(x => x.BookFormatId.HasValue);

        RuleFor(x => x.Price)
            .NotNull().WithMessage("Price is required.")
            .GreaterThan(0m).When(x => x.Price.HasValue);

        RuleFor(x => x.PageCount)
            .NotNull().WithMessage("Page count is required.")
            .GreaterThan(0).When(x => x.PageCount.HasValue);

        RuleFor(x => x.CategoryIds).NotEmpty().WithMessage("At least one category is required.");
        RuleFor(x => x.AuthorIds).NotEmpty().WithMessage("At least one author is required.");
    }
}
