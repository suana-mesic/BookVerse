using BookVerse.Application.Modules.Auth.Commands.Login;

namespace BookVerse.Tests.AuthTests.UnitTests;

public class LoginValidatorUnitTests
{
    private readonly LoginCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var command = new LoginCommand
        {
            Email = "user@bookverse.com",
            Password = "password123"
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithEmptyEmail_ShouldHaveEmailError()
    {
        var command = new LoginCommand
        {
            Email = "",
            Password = "password123"
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Email));
    }

    [Fact]
    public void Validate_WithShortPassword_ShouldHavePasswordError()
    {
        var command = new LoginCommand
        {
            Email = "user@bookverse.com",
            Password = "abc"
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Password));
    }

    [Fact]
    public void Validate_WithTooLongFingerprint_ShouldHaveFingerprintError()
    {
        var command = new LoginCommand
        {
            Email = "user@bookverse.com",
            Password = "password123",
            Fingerprint = new string('x', 257)
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Fingerprint));
    }

    [Fact]
    public void Validate_WithNullFingerprint_ShouldNotHaveErrors()
    {
        var command = new LoginCommand
        {
            Email = "user@bookverse.com",
            Password = "password123",
            Fingerprint = null
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
    }
}
