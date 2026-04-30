using BookVerse.Application.Modules.Catalog.Authors.Commands.Create;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class CreateAuthorValidatorUnitTests
{
    private readonly CreateAuthorCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var command = new CreateAuthorCommand
        {
            FirstName = "Meša",
            LastName = "Selimović",
            Country = "Bosna i Hercegovina"
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithEmptyFirstName_ShouldHaveError()
    {
        var command = new CreateAuthorCommand
        {
            FirstName = "",
            LastName = "Selimović",
            Country = "Bosna i Hercegovina"
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.FirstName));
    }

    [Fact]
    public void Validate_WithEmptyLastName_ShouldHaveError()
    {
        var command = new CreateAuthorCommand
        {
            FirstName = "Meša",
            LastName = "",
            Country = "Bosna i Hercegovina"
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.LastName));
    }

    [Fact]
    public void Validate_WithEmptyCountry_ShouldHaveError()
    {
        var command = new CreateAuthorCommand
        {
            FirstName = "Meša",
            LastName = "Selimović",
            Country = ""
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Country));
    }

    [Fact]
    public void Validate_WithAllFieldsMissing_ShouldHaveMultipleErrors()
    {
        var command = new CreateAuthorCommand { FirstName = "", LastName = "", Country = "" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.True(result.Errors.Count >= 3);
    }
}
