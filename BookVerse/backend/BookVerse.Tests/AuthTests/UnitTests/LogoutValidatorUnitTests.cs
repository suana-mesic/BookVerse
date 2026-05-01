using BookVerse.Application.Modules.Auth.Commands.Logout;

namespace BookVerse.Tests.AuthTests.UnitTests;

public class LogoutValidatorUnitTests
{
    private readonly LogoutCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidRefreshToken_ShouldNotHaveErrors()
    {
        var command = new LogoutCommand { RefreshToken = "valid-refresh-token" };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithEmptyRefreshToken_ShouldHaveError()
    {
        var command = new LogoutCommand { RefreshToken = "" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.RefreshToken));
    }

    [Fact]
    public void Validate_WithWhitespaceRefreshToken_ShouldHaveError()
    {
        var command = new LogoutCommand { RefreshToken = "   " };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.RefreshToken));
    }
}
