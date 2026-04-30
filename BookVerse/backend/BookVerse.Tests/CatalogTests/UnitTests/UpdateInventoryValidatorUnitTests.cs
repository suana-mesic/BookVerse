using BookVerse.Application.Modules.Catalog.Inventory.Commands.Update;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class UpdateInventoryValidatorUnitTests
{
    private readonly UpdateInventoryCommandValidator _validator = new();

    private static UpdateInventoryCommand ValidCommand() => new()
    {
        OldStoreId = 1,
        OldBookId = 1,
        StoreId = 2,
        BookId = 2,
        QuantityInStock = 10,
        ReorderTreshold = 5
    };

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var result = _validator.Validate(ValidCommand());

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithZeroOldStoreId_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.OldStoreId = 0;

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.OldStoreId));
    }

    [Fact]
    public void Validate_WithZeroOldBookId_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.OldBookId = 0;

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.OldBookId));
    }

    [Fact]
    public void Validate_WithZeroNewStoreId_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.StoreId = 0;

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.StoreId));
    }

    [Fact]
    public void Validate_WithZeroNewBookId_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.BookId = 0;

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.BookId));
    }

    [Fact]
    public void Validate_WithNegativeQuantity_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.QuantityInStock = -1;

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.QuantityInStock));
    }

    [Fact]
    public void Validate_WithZeroReorderThreshold_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.ReorderTreshold = 0;

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.ReorderTreshold));
    }
}
