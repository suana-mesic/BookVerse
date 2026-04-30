using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Update.ChangeStatus;

namespace BookVerse.Application.Modules.Sales.Orders.Commands.Status;

public sealed class ChangeOrderStatusCommandValidator : AbstractValidator<ChangeOrderStatusCommand>
{
    public ChangeOrderStatusCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Order Id must be greater than 0.");
    }
}