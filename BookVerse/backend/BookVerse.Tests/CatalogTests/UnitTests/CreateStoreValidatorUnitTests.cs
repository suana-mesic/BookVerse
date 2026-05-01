using BookVerse.Application.Modules.Catalog.Stores.Commands.Create;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class CreateStoreValidatorUnitTests
{
    private readonly CreateStoreCommandValidator _validator = new();

    private static CreateStoreCommand ValidCommand() => new()
    {
        StoreName = "Central Bookstore",
        AddressId = 1,
        Phone = "061-123-456",
        Email = "central@bookverse.ba",
        OpeningHours = "Mon-Fri 9-17h"
    };

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var result = _validator.Validate(ValidCommand());

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithEmptyStoreName_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.StoreName = "";

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.StoreName));
    }

    [Fact]
    public void Validate_WithZeroAddressId_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.AddressId = 0;

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.AddressId));
    }

    [Fact]
    public void Validate_WithEmptyPhone_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.Phone = "";

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.Phone));
    }

    [Fact]
    public void Validate_WithEmptyEmail_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.Email = "";

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.Email));
    }

    [Fact]
    public void Validate_WithEmptyOpeningHours_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.OpeningHours = "";

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.OpeningHours));
    }

    [Fact]
    public void Validate_WithTooLongStoreName_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.StoreName = new string('x', 101);

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.StoreName));
    }
}
