using BookVerse.Application.Modules.Catalog.Publishers.Commands.Create;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class CreatePublisherValidatorUnitTests
{
    private readonly CreatePublisherCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var command = new CreatePublisherCommand
        {
            Name = "Buybook",
            City = "Sarajevo",
            Country = "Bosna i Hercegovina"
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithEmptyName_ShouldHaveError()
    {
        var command = new CreatePublisherCommand { Name = "", City = "Sarajevo", Country = "Bosna i Hercegovina" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Name));
    }

    [Fact]
    public void Validate_WithEmptyCity_ShouldHaveError()
    {
        var command = new CreatePublisherCommand { Name = "Buybook", City = "", Country = "Bosna i Hercegovina" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.City));
    }

    [Fact]
    public void Validate_WithEmptyCountry_ShouldHaveError()
    {
        var command = new CreatePublisherCommand { Name = "Buybook", City = "Sarajevo", Country = "" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Country));
    }

    [Fact]
    public void Validate_WithTooLongName_ShouldHaveError()
    {
        var command = new CreatePublisherCommand
        {
            Name = new string('x', 101),
            City = "Sarajevo",
            Country = "Bosna i Hercegovina"
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Name));
    }
}
