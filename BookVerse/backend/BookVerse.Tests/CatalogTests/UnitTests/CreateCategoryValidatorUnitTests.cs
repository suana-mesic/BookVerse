using BookVerse.Application.Modules.Catalog.Categories.Commands.Create;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class CreateCategoryValidatorUnitTests
{
    private readonly CreateCategoryCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidName_ShouldNotHaveErrors()
    {
        var command = new CreateCategoryCommand { Name = "Romani" };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithEmptyName_ShouldHaveError()
    {
        var command = new CreateCategoryCommand { Name = "" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Name));
    }

    [Fact]
    public void Validate_WithTooLongName_ShouldHaveError()
    {
        var command = new CreateCategoryCommand { Name = new string('a', 101) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Name));
    }

    [Fact]
    public void Validate_WithMaxLengthName_ShouldBeValid()
    {
        var command = new CreateCategoryCommand { Name = new string('a', 100) };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
    }
}
