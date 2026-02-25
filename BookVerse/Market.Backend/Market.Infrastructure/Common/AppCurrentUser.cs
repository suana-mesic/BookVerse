using Market.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace Market.Infrastructure.Common;

/// <summary>
/// Implementation of IAppCurrentUser that reads data from a JWT token.
/// </summary>
public sealed class AppCurrentUser(IHttpContextAccessor httpContextAccessor)
    : IAppCurrentUser
{
    private readonly ClaimsPrincipal? _user = httpContextAccessor.HttpContext?.User;

    public int? UserId =>
        int.TryParse(_user?.FindFirstValue(ClaimTypes.NameIdentifier), out var id)
            ? id
            : null;

    public string? FirstName =>
      _user?.FindFirstValue("firstName");
    public string? LastName =>
  _user?.FindFirstValue("lastName");
    public string? Email =>
        string.Join(' ', new[] {FirstName, LastName}.Where(x=>!string.IsNullOrWhiteSpace(x)));
    public string? FullName =>
    _user?.FindFirstValue(ClaimTypes.Email);

    public bool IsAuthenticated =>
        _user?.Identity?.IsAuthenticated ?? false;

    public bool IsAdmin =>
        _user?.FindFirstValue("is_admin")?.Equals("true", StringComparison.OrdinalIgnoreCase) ?? false;

    public bool IsManager =>
        _user?.FindFirstValue("is_manager")?.Equals("true", StringComparison.OrdinalIgnoreCase) ?? false;

    public bool IsEmployee =>
        _user?.FindFirstValue("is_employee")?.Equals("true", StringComparison.OrdinalIgnoreCase) ?? false;
}