using BookVerse.Application.Modules.Catalog.Inventory.Commands.Create;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class CreateInventoryValidatorUnitTests
{
    private readonly CreateInventoryCommandValidator _validator = new();

    private static InventoryInfo ValidItem() => new()
    {
        StoreId = 1,
        BookId = 1,
        QuantityInStock = 10,
        ReorderTreshold = 5
    };

    [Fact]
    public void Validate_WithValidItems_ShouldNotHaveErrors()
    {
        var command = new CreateInventoryCommand { InventoryInfo = [ValidItem()] };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithZeroStoreId_ShouldHaveError()
    {
        var item = ValidItem();
        item.StoreId = 0;
        var command = new CreateInventoryCommand { InventoryInfo = [item] };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName.Contains("StoreId"));
    }

    [Fact]
    public void Validate_WithZeroBookId_ShouldHaveError()
    {
        var item = ValidItem();
        item.BookId = 0;
        var command = new CreateInventoryCommand { InventoryInfo = [item] };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName.Contains("BookId"));
    }

    [Fact]
    public void Validate_WithNegativeQuantity_ShouldHaveError()
    {
        var item = ValidItem();
        item.QuantityInStock = -1;
        var command = new CreateInventoryCommand { InventoryInfo = [item] };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName.Contains("QuantityInStock"));
    }

    [Fact]
    public void Validate_WithZeroReorderThreshold_ShouldHaveError()
    {
        var item = ValidItem();
        item.ReorderTreshold = 0;
        var command = new CreateInventoryCommand { InventoryInfo = [item] };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName.Contains("ReorderTreshold"));
    }

    [Fact]
    public void Validate_WithZeroQuantity_ShouldBeValid()
    {
        var item = ValidItem();
        item.QuantityInStock = 0;
        var command = new CreateInventoryCommand { InventoryInfo = [item] };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
    }
}
