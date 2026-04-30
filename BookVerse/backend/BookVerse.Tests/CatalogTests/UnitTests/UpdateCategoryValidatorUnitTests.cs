using BookVerse.Application.Modules.Catalog.Categories.Commands.Update;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class UpdateCategoryValidatorUnitTests
{
    private readonly UpdateCategoryCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var command = new UpdateCategoryCommand { Id = 1, Name = "Romani" };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithZeroId_ShouldHaveError()
    {
        var command = new UpdateCategoryCommand { Id = 0, Name = "Romani" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Id));
    }

    [Fact]
    public void Validate_WithNegativeId_ShouldHaveError()
    {
        var command = new UpdateCategoryCommand { Id = -1, Name = "Romani" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Id));
    }

    [Fact]
    public void Validate_WithEmptyName_ShouldHaveError()
    {
        var command = new UpdateCategoryCommand { Id = 1, Name = "" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Name));
    }

    [Fact]
    public void Validate_WithTooLongName_ShouldHaveError()
    {
        var command = new UpdateCategoryCommand { Id = 1, Name = new string('x', 101) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Name));
    }

    [Fact]
    public void Validate_WithMaxLengthName_ShouldBeValid()
    {
        var command = new UpdateCategoryCommand { Id = 5, Name = new string('a', 100) };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
    }
}
