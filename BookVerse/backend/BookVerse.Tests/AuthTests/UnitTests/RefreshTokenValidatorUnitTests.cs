using BookVerse.Application.Modules.Auth.Commands.Refresh;

namespace BookVerse.Tests.AuthTests.UnitTests;

public class RefreshTokenValidatorUnitTests
{
    private readonly RefreshTokenCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var command = new RefreshTokenCommand
        {
            RefreshToken = "valid-refresh-token-string",
            Fingerprint = "browser-fingerprint"
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithEmptyRefreshToken_ShouldHaveError()
    {
        var command = new RefreshTokenCommand { RefreshToken = "" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.RefreshToken));
    }

    [Fact]
    public void Validate_WithNullFingerprint_ShouldBeValid()
    {
        var command = new RefreshTokenCommand
        {
            RefreshToken = "some-refresh-token",
            Fingerprint = null
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_WithTooLongFingerprint_ShouldHaveError()
    {
        var command = new RefreshTokenCommand
        {
            RefreshToken = "some-refresh-token",
            Fingerprint = new string('x', 257)
        };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Fingerprint));
    }

    [Fact]
    public void Validate_WithMaxLengthFingerprint_ShouldBeValid()
    {
        var command = new RefreshTokenCommand
        {
            RefreshToken = "some-refresh-token",
            Fingerprint = new string('x', 256)
        };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
    }
}
