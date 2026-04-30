namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.List;

public sealed class ListOrderOrderItemsQueryValidator : AbstractValidator<ListOrderOrderItemsQuery>
{
    public ListOrderOrderItemsQueryValidator()
    {
        RuleFor(x => x.Paging.Page).GreaterThan(0).WithMessage("Page must be greater than zero.");
        RuleFor(x => x.Paging.PageSize).GreaterThan(0).WithMessage("PageSize must be greater than zero.");
        RuleFor(x => x.Search).MaximumLength(200).When(x => x.Search is not null);
        RuleFor(x => x.Status).IsInEnum().When(x => x.Status.HasValue);
    }
}
