using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Book.Commands.Create;

public sealed class CreateBookCommandValidator
    : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.ISBN)
            .NotEmpty().WithMessage("ISBN is required.")
            .MaximumLength(Books.Constraints.ISBNMaxLength).WithMessage($"ISBN can be at most {Books.Constraints.ISBNMaxLength} characters long.")
            .Must(IsbnValidator.IsValid).WithMessage("ISBN is not valid. Must be a valid ISBN-10 or ISBN-13 with correct check digit.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(Books.Constraints.TitleMaxLength).WithMessage($"Title can be at most {Books.Constraints.TitleMaxLength} characters long.");

        RuleFor(x => x.LanguageId).GreaterThan(0).WithMessage("Language is required.");

        RuleFor(x => x.PublisherId).GreaterThan(0).WithMessage("Publisher is required.");
        RuleFor(x => x.BookFormatId).GreaterThan(0).WithMessage("Book format is required.");
        RuleFor(x => x.Price).GreaterThan(0m).WithMessage("Price must be greater than 0.");
        RuleFor(x => x.PageCount).GreaterThan(0).WithMessage("Page count must be greater than 0.");
        RuleFor(x => x.CategoryIds).NotEmpty().WithMessage("At least one category is required.");
        RuleFor(x => x.AuthorIds).NotEmpty().WithMessage("At least one author is required.");
    }
}
