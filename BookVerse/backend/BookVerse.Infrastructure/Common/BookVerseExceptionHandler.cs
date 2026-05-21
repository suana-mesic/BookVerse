using FluentValidation;
using BookVerse.Application.Common.Exceptions;
using BookVerse.Shared.Dtos;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BookVerse.Infrastructure.Common;

/// <summary>
/// Global exception handler for unhandled exceptions.
/// Keeps the same ErrorDto format as the previous middleware.
/// </summary>
public sealed class BookVerseExceptionHandler(
    ILogger<BookVerseExceptionHandler> logger,
    IHostEnvironment env
) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext ctx, Exception ex, CancellationToken ct)
    {
        // If the response has already started, let it bubble up
        if (ctx.Response.HasStarted)
        {
            logger.LogWarning(ex, "Response already started, letting the exception bubble.");
            return false;
        }

        var traceId = Activity.Current?.Id ?? ctx.TraceIdentifier;

        logger.LogError(ex,
            "Unhandled exception. Path: {Path}, Method: {Method}, TraceId: {TraceId}, User: {User}",
            ctx.Request.Path,
            ctx.Request.Method,
            traceId,
            ctx.User.Identity?.Name ?? "anonymous");


        ctx.Response.ContentType = "application/json";
        ctx.Response.StatusCode = ex switch
        {
            BookVerseNotFoundException => StatusCodes.Status404NotFound,
            // 401 is mapped FIRST so it wins over 409 for auth failures.
            // This lets the frontend auth-interceptor pick up the response and trigger refresh/logout.
            BookVerseUnauthorizedException => StatusCodes.Status401Unauthorized,
            BookVerseConflictException or BookVerseBusinessRuleException => StatusCodes.Status409Conflict,
            ValidationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        var error = BuildErrorDto(ex, env.IsDevelopment(), traceId);

        await ctx.Response.WriteAsJsonAsync(error, cancellationToken: ct);
        return true; // prevents rethrowing the exception
    }

    private static ErrorDto BuildErrorDto(Exception ex, bool isDev, string traceId)
    {
        string code = "internal.error";
        string message = "An error occurred. Please try again.";
        List<FieldErrorDto>? fieldErrors = null;

        switch (ex)
        {
            case BookVerseNotFoundException:
            case BookVerseConflictException:
                code = "entity.error";
                message = ex.Message;
                break;

            // Business-rule errors carry a meaningful Code (see BusinessRuleCodes) which the
            // frontend uses as an i18n key. Propagate it AS-IS instead of replacing it with
            // the generic "entity.error" so the localization lookup actually works.
            case BookVerseBusinessRuleException brex:
                code = brex.Code;
                message = ex.Message;
                break;

            case BookVerseUnauthorizedException:
                // Dedicated "auth.error" code so the frontend can distinguish auth failures
                // from generic business errors in the response payload.
                code = "auth.error";
                message = ex.Message;
                break;

            case ValidationException vex:
                code = "validation.error";
                // Keep a short top-level message for callers (logs, generic toasts) and put the
                // per-field detail in FieldErrors so the frontend can highlight inputs inline.
                message = "Validation failed.";
                // PropertyName is camelCased so it matches the form-control names the frontend uses
                // (Angular form controls are camelCase like "firstName", FluentValidation reports "FirstName").
                fieldErrors = vex.Errors
                    .Select(e => new FieldErrorDto
                    {
                        Field = ToCamelCase(e.PropertyName),
                        Message = e.ErrorMessage,
                        ErrorCode = e.ErrorCode
                    })
                    .ToList();
                break;
        }

        return new ErrorDto
        {
            Code = code,
            Message = message,
            TraceId = traceId,
            Details = isDev ? ex.ToString() : null, // stack trace only in Development environment
            FieldErrors = fieldErrors
        };
    }

    // FluentValidation reports PascalCase property names ("FirstName"). Angular form controls are
    // camelCase ("firstName"). We lower-case the first character so the frontend can look up the
    // matching control directly without doing the conversion on every form.
    private static string ToCamelCase(string propertyName)
    {
        if (string.IsNullOrEmpty(propertyName)) return propertyName;
        return char.ToLowerInvariant(propertyName[0]) + propertyName.Substring(1);
    }
}
