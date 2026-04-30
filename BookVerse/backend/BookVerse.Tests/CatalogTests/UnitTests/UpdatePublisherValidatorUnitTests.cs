using BookVerse.Application.Modules.Catalog.Publishers.Commands.Update;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class UpdatePublisherValidatorUnitTests
{
    private readonly UpdatePublisherCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var command = new UpdatePublisherCommand { Id = 1, Name = "New Name", City = "Mostar", Country = "BiH" };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithAllNullOptionalFields_ShouldBeValid()
    {
        var command = new UpdatePublisherCommand { Id = 2 };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_WithZeroId_ShouldHaveError()
    {
        var command = new UpdatePublisherCommand { Id = 0 };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Id));
    }

    [Fact]
    public void Validate_WithNegativeId_ShouldHaveError()
    {
        var command = new UpdatePublisherCommand { Id = -3 };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Id));
    }

    [Fact]
    public void Validate_WithTooLongName_ShouldHaveError()
    {
        var command = new UpdatePublisherCommand { Id = 1, Name = new string('x', 101) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Name));
    }

    [Fact]
    public void Validate_WithTooLongCity_ShouldHaveError()
    {
        var command = new UpdatePublisherCommand { Id = 1, City = new string('x', 101) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.City));
    }

    [Fact]
    public void Validate_WithTooLongCountry_ShouldHaveError()
    {
        var command = new UpdatePublisherCommand { Id = 1, Country = new string('x', 101) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Country));
    }
}
