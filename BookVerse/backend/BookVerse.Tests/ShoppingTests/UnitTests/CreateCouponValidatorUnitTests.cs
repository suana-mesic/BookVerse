using BookVerse.Application.Modules.Shopping.Coupons.Commands;

namespace BookVerse.Tests.ShoppingTests.UnitTests;

public class CreateCouponValidatorUnitTests
{
    private readonly CreateCouponCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var command = new CreateCouponCommand
        {
            Name = "Summer Sale",
            PromotionCode = "SUMMER25",
            AmountOff = 5m,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(30)
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithEmptyName_ShouldHaveError()
    {
        var command = new CreateCouponCommand
        {
            Name = "",
            PromotionCode = "CODE123",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(10)
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Name));
    }

    [Fact]
    public void Validate_WithEmptyPromotionCode_ShouldHaveError()
    {
        var command = new CreateCouponCommand
        {
            Name = "Discount",
            PromotionCode = "",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(10)
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.PromotionCode));
    }

    [Fact]
    public void Validate_WithTooLongName_ShouldHaveError()
    {
        var command = new CreateCouponCommand
        {
            Name = new string('x', 101),
            PromotionCode = "CODE123",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(10)
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Name));
    }

    [Fact]
    public void Validate_WithTooLongDescription_ShouldHaveError()
    {
        var command = new CreateCouponCommand
        {
            Name = "Discount",
            PromotionCode = "CODE123",
            Description = new string('x', 201),
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(10)
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Description));
    }

    [Fact]
    public void Validate_WithNullDescription_ShouldNotHaveDescriptionError()
    {
        var command = new CreateCouponCommand
        {
            Name = "Discount",
            PromotionCode = "CODE123",
            Description = null,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(10)
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
    }
}
