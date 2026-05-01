using BookVerse.Application.Modules.Catalog.Stores.Commands.Update;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class UpdateStoreValidatorUnitTests
{
    private readonly UpdateStoreCommandValidator _validator = new();

    [Fact]
    public void Validate_WithAllNullFields_ShouldBeValid()
    {
        var command = new UpdateStoreCommand { Id = 1 };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithValidFields_ShouldBeValid()
    {
        var command = new UpdateStoreCommand
        {
            Id = 1,
            StoreName = "New Bookstore",
            Phone = "061-000-001",
            Email = "nova@bookverse.ba"
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithTooLongStoreName_ShouldHaveError()
    {
        var command = new UpdateStoreCommand { Id = 1, StoreName = new string('x', 101) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.StoreName));
    }

    [Fact]
    public void Validate_WithTooLongPhone_ShouldHaveError()
    {
        var command = new UpdateStoreCommand { Id = 1, Phone = new string('9', 21) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Phone));
    }

    [Fact]
    public void Validate_WithTooLongEmail_ShouldHaveError()
    {
        var command = new UpdateStoreCommand { Id = 1, Email = new string('a', 95) + "@test.ba" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Email));
    }
}
