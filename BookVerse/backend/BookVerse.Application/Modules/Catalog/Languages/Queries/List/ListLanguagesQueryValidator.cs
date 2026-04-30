namespace BookVerse.Application.Modules.Catalog.Languages.Queries.List;

public sealed class ListLanguagesQueryValidator : AbstractValidator<ListLanguagesQuery>
{
    public ListLanguagesQueryValidator()
    {
        RuleFor(x => x.Language).MaximumLength(10).When(x => x.Language is not null);
    }
}
