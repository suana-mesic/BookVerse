using BookVerse.Application.Modules.Catalog.Book.Commands.Update;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class UpdateBookValidatorUnitTests
{
    private readonly UpdateBookCommandValidator _validator = new();

    private static UpdateBookCommand ValidCommand() => new()
    {
        Id = 1,
        ISBN = "9780306406157",
        Title = "Updated Book",
        CategoryIds = [1],
        AuthorIds = [1],
        Price = 19.99m,
        PageCount = 200
    };

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var result = _validator.Validate(ValidCommand());

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithZeroId_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.Id = 0;

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.Id));
    }

    [Fact]
    public void Validate_WithEmptyISBN_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.ISBN = "";

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.ISBN));
    }

    [Fact]
    public void Validate_WithInvalidISBN_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.ISBN = "1234567890123"; // wrong check digit

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.ISBN));
    }

    [Fact]
    public void Validate_WithEmptyTitle_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.Title = "";

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.Title));
    }

    [Fact]
    public void Validate_WithEmptyCategoryIds_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.CategoryIds = [];

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.CategoryIds));
    }

    [Fact]
    public void Validate_WithEmptyAuthorIds_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.AuthorIds = [];

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.AuthorIds));
    }

    [Fact]
    public void Validate_WithZeroPrice_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.Price = 0m;

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.Price));
    }

    [Fact]
    public void Validate_WithZeroPageCount_ShouldHaveError()
    {
        var cmd = ValidCommand();
        cmd.PageCount = 0;

        var result = _validator.Validate(cmd);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(cmd.PageCount));
    }
}
