namespace BookVerse.Application.Modules.Reports.Orders;

public sealed class GenerateOrdersReportQueryValidator : AbstractValidator<GenerateOrdersReportQuery>
{
    public GenerateOrdersReportQueryValidator()
    {
        RuleFor(x => x.DateFrom).NotEmpty().WithMessage("DateFrom is required.");
        RuleFor(x => x.DateTo).NotEmpty().WithMessage("DateTo is required.");
        RuleFor(x => x).Must(x => x.DateFrom <= x.DateTo)
            .WithMessage("DateFrom must be earlier than or equal to DateTo.");
        RuleFor(x => x.UserId).NotNull().WithMessage("UserId is required.").GreaterThan(0).When(x => x.UserId.HasValue);
        RuleFor(x => x.Language)
            .NotEmpty().WithMessage("Language is required.")
            .MaximumLength(10);
    }
}
