using BookVerse.Application.Modules.Catalog.Book.Commands.Create;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class CreateBookValidatorUnitTests
{
    private readonly CreateBookCommandValidator _validator = new();

    private static CreateBookCommand ValidCommand() => new()
    {
        ISBN        = "9780306406157",
        Title       = "Derviš i smrt",
        PublisherId = 1,
        BookFormatId = 1,
        LanguageId  = 1,
        Price       = 29.99m,
        PageCount   = 350,
        CategoryIds = [1],
        AuthorIds   = [1],
        PublishedDate = new DateTime(2000, 1, 1)
    };

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var result = _validator.Validate(ValidCommand());

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithInvalidIsbn_ShouldHaveIsbnError()
    {
        var command = ValidCommand();
        command.ISBN = "1111111111111";

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.ISBN));
    }

    [Fact]
    public void Validate_WithZeroPrice_ShouldHavePriceError()
    {
        var command = ValidCommand();
        command.Price = 0m;

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Price));
    }

    [Fact]
    public void Validate_WithEmptyTitle_ShouldHaveTitleError()
    {
        var command = ValidCommand();
        command.Title = "";

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Title));
    }

    [Fact]
    public void Validate_WithNoCategoryIds_ShouldHaveCategoryError()
    {
        var command = ValidCommand();
        command.CategoryIds = [];

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.CategoryIds));
    }

    [Fact]
    public void Validate_WithZeroPageCount_ShouldHavePageCountError()
    {
        var command = ValidCommand();
        command.PageCount = 0;

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.PageCount));
    }
}
