using BookVerse.Application.Modules.Catalog.Addresses.Commands.Create;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class CreateAddressValidatorUnitTests
{
    private readonly CreateAddressCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var command = new CreateAddressCommand
        {
            Line1 = "Ferhadija 1",
            City = "Sarajevo",
            Country = "Bosnia and Herzegovina"
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithEmptyLine1_ShouldHaveError()
    {
        var command = new CreateAddressCommand { Line1 = "", City = "Sarajevo", Country = "BiH" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Line1));
    }

    [Fact]
    public void Validate_WithEmptyCity_ShouldHaveError()
    {
        var command = new CreateAddressCommand { Line1 = "Ferhadija 1", City = "", Country = "BiH" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.City));
    }

    [Fact]
    public void Validate_WithEmptyCountry_ShouldHaveError()
    {
        var command = new CreateAddressCommand { Line1 = "Ferhadija 1", City = "Sarajevo", Country = "" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Country));
    }

    [Fact]
    public void Validate_WithTooLongLine1_ShouldHaveError()
    {
        var command = new CreateAddressCommand
        {
            Line1 = new string('x', 101),
            City = "Sarajevo",
            Country = "BiH"
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Line1));
    }

    [Fact]
    public void Validate_WithOptionalLine2TooLong_ShouldHaveError()
    {
        var command = new CreateAddressCommand
        {
            Line1 = "Ferhadija 1",
            Line2 = new string('x', 101),
            City = "Sarajevo",
            Country = "BiH"
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Line2));
    }
}
