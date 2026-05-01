namespace BookVerse.Application.Modules.Reports.Books;

public sealed class GenerateBooksReportQueryValidator : AbstractValidator<GenerateBooksReportQuery>
{
    public GenerateBooksReportQueryValidator()
    {
        RuleFor(x => x.DateFrom).NotEmpty().WithMessage("DateFrom is required.");
        RuleFor(x => x.DateTo).NotEmpty().WithMessage("DateTo is required.");
        RuleFor(x => x).Must(x => x.DateFrom <= x.DateTo)
            .WithMessage("DateFrom must be earlier than or equal to DateTo.");
        RuleFor(x => x.BookId).NotNull().WithMessage("BookId is required.").GreaterThan(0).When(x => x.BookId.HasValue);
        RuleFor(x => x.Language)
            .NotEmpty().WithMessage("Language is required.")
            .MaximumLength(10);
    }
}
