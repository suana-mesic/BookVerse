using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Update.ChangeStatus;
using BookVerse.Application.Modules.Sales.Orders.Commands.Status;
using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Tests.ShoppingTests.UnitTests;

public class ChangeOrderStatusValidatorUnitTests
{
    private readonly ChangeOrderStatusCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidId_ShouldNotHaveErrors()
    {
        var command = new ChangeOrderStatusCommand { Id = 1, NewStatus = OrderStatusType.Packed };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithZeroId_ShouldHaveError()
    {
        var command = new ChangeOrderStatusCommand { Id = 0, NewStatus = OrderStatusType.Packed };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Id));
    }

    [Fact]
    public void Validate_WithNegativeId_ShouldHaveError()
    {
        var command = new ChangeOrderStatusCommand { Id = -5, NewStatus = OrderStatusType.Shipped };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Id));
    }
}
