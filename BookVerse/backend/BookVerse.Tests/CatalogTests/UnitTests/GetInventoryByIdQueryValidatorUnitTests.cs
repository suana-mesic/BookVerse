using BookVerse.Application.Modules.Catalog.Inventory.Queries.GetById;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class GetInventoryByIdQueryValidatorUnitTests
{
    private readonly GetInventoryByIdQueryValidator _validator = new();

    [Fact]
    public void Validate_WithValidIds_ShouldNotHaveErrors()
    {
        var query = new GetInventoryByIdQuery { StoreId = 1, BookId = 1 };

        var result = _validator.Validate(query);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithZeroBookId_ShouldHaveError()
    {
        var query = new GetInventoryByIdQuery { StoreId = 1, BookId = 0 };

        var result = _validator.Validate(query);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(query.BookId));
    }

    [Fact]
    public void Validate_WithZeroStoreId_ShouldHaveError()
    {
        var query = new GetInventoryByIdQuery { StoreId = 0, BookId = 1 };

        var result = _validator.Validate(query);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(query.StoreId));
    }

    [Fact]
    public void Validate_WithNegativeBookId_ShouldHaveError()
    {
        var query = new GetInventoryByIdQuery { StoreId = 1, BookId = -5 };

        var result = _validator.Validate(query);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(query.BookId));
    }

    [Fact]
    public void Validate_WithNegativeStoreId_ShouldHaveError()
    {
        var query = new GetInventoryByIdQuery { StoreId = -1, BookId = 1 };

        var result = _validator.Validate(query);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(query.StoreId));
    }

    [Fact]
    public void Validate_WithBothIdsZero_ShouldHaveMultipleErrors()
    {
        var query = new GetInventoryByIdQuery { StoreId = 0, BookId = 0 };

        var result = _validator.Validate(query);

        Assert.False(result.IsValid);
        Assert.True(result.Errors.Count >= 2);
    }
}
