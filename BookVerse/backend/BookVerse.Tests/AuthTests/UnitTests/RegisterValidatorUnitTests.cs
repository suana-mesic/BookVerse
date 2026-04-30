using BookVerse.Application.Modules.Auth.Commands.Register;

namespace BookVerse.Tests.AuthTests.UnitTests;

public class RegisterValidatorUnitTests
{
    private readonly RegisterCommandValidator _validator = new();

    private static RegisterCommand ValidCommand() => new()
    {
        FirstName = "Amina",
        LastName  = "Hodžić",
        Email     = "amina.hodzic@bookverse.com",
        Password  = "password123",
        Line1     = "Street 1",
        City      = "Sarajevo",
        Country   = "Bosnia and Herzegovina"
    };

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var result = _validator.Validate(ValidCommand());

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithEmptyFirstName_ShouldHaveError()
    {
        var command = ValidCommand();
        command.FirstName = "";

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.FirstName));
    }

    [Fact]
    public void Validate_WithEmptyEmail_ShouldHaveError()
    {
        var command = new RegisterCommand
        {
            FirstName = "Amina",
            LastName  = "Hodžić",
            Email     = "",
            Password  = "password123",
            Line1     = "Street 1",
            City      = "Sarajevo",
            Country   = "Bosnia and Herzegovina"
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Email));
    }

    [Fact]
    public void Validate_WithShortPassword_ShouldHaveError()
    {
        var command = new RegisterCommand
        {
            FirstName = "Amina",
            LastName  = "Hodžić",
            Email     = "amina@bookverse.com",
            Password  = "abc",
            Line1     = "Street 1",
            City      = "Sarajevo",
            Country   = "Bosnia and Herzegovina"
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Password));
    }

    [Fact]
    public void Validate_WithEmptyCity_ShouldHaveError()
    {
        var command = new RegisterCommand
        {
            FirstName = "Amina",
            LastName  = "Hodžić",
            Email     = "amina@bookverse.com",
            Password  = "password123",
            Line1     = "Street 1",
            City      = "",
            Country   = "Bosnia and Herzegovina"
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.City));
    }
}
