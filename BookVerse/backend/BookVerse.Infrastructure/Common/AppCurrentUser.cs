using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using BookVerse.Application.Abstractions;

namespace BookVerse.Infrastructure.Common;

/// <summary>
/// Implementation of IAppCurrentUser that reads data from a JWT token.
/// </summary>
public sealed class AppCurrentUser(IHttpContextAccessor httpContextAccessor)
    : IAppCurrentUser
{
    // Read the ClaimsPrincipal LAZILY on each property access instead of capturing it
    // once in the constructor. Capturing in the constructor only works when the service
    // is created inside an HTTP request scope; in a SignalR hub the HttpContext is null
    // at construction time but becomes available later, so a captured reference would
    // be permanently null even if the user is actually authenticated. The lazy getter
    // re-reads the accessor every time, so it works in both HTTP and SignalR scopes.
    private ClaimsPrincipal? User => httpContextAccessor.HttpContext?.User;

    public int? UserId =>
        int.TryParse(User?.FindFirstValue(ClaimTypes.NameIdentifier), out var id)
            ? id
            : null;

    public string? Email =>
        User?.FindFirstValue(ClaimTypes.Email);

    public bool IsAuthenticated =>
        User?.Identity?.IsAuthenticated ?? false;

    public bool IsAdmin =>
        User?.FindFirstValue("is_admin")?.Equals("true", StringComparison.OrdinalIgnoreCase) ?? false;

    public bool IsManager =>
        User?.FindFirstValue("is_manager")?.Equals("true", StringComparison.OrdinalIgnoreCase) ?? false;

    public bool IsEmployee =>
        User?.FindFirstValue("is_employee")?.Equals("true", StringComparison.OrdinalIgnoreCase) ?? false;
}