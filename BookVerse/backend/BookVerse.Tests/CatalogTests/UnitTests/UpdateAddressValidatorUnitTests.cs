using BookVerse.Application.Modules.Catalog.Addresses.Commands.Update;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class UpdateAddressValidatorUnitTests
{
    private readonly UpdateAddressCommandValidator _validator = new();

    [Fact]
    public void Validate_WithAllNullFields_ShouldBeValid()
    {
        var command = new UpdateAddressCommand { Id = 1 };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithValidFields_ShouldBeValid()
    {
        var command = new UpdateAddressCommand
        {
            Id = 1,
            Line1 = "New Street 5",
            City = "Mostar",
            Country = "Bosnia and Herzegovina"
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithTooLongLine1_ShouldHaveError()
    {
        var command = new UpdateAddressCommand { Id = 1, Line1 = new string('x', 101) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Line1));
    }

    [Fact]
    public void Validate_WithTooLongCity_ShouldHaveError()
    {
        var command = new UpdateAddressCommand { Id = 1, City = new string('x', 51) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.City));
    }

    [Fact]
    public void Validate_WithTooLongCountry_ShouldHaveError()
    {
        var command = new UpdateAddressCommand { Id = 1, Country = new string('x', 51) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Country));
    }
}
