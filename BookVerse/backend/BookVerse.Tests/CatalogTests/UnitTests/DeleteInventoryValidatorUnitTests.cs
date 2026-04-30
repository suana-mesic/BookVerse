using BookVerse.Application.Modules.Catalog.Inventory.Commands.Delete;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class DeleteInventoryValidatorUnitTests
{
    private readonly DeleteInventoryCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidIds_ShouldNotHaveErrors()
    {
        var command = new DeleteInventoryCommand { StoreId = 1, BookId = 1 };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithZeroBookId_ShouldHaveError()
    {
        var command = new DeleteInventoryCommand { StoreId = 1, BookId = 0 };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.BookId));
    }

    [Fact]
    public void Validate_WithZeroStoreId_ShouldHaveError()
    {
        var command = new DeleteInventoryCommand { StoreId = 0, BookId = 1 };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.StoreId));
    }

    [Fact]
    public void Validate_WithNegativeBookId_ShouldHaveError()
    {
        var command = new DeleteInventoryCommand { StoreId = 1, BookId = -1 };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.BookId));
    }

    [Fact]
    public void Validate_WithNegativeStoreId_ShouldHaveError()
    {
        var command = new DeleteInventoryCommand { StoreId = -1, BookId = 1 };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.StoreId));
    }

    [Fact]
    public void Validate_WithBothIdsZero_ShouldHaveMultipleErrors()
    {
        var command = new DeleteInventoryCommand { StoreId = 0, BookId = 0 };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.True(result.Errors.Count >= 2);
    }
}
