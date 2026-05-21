namespace BookVerse.Application.Common.Exceptions;

// Thrown for authentication failures: wrong password, expired tokens, invalid 2FA codes,
// lockouts, etc. The exception handler maps this to HTTP 401 so the frontend's auth
// interceptor can react properly (e.g. try a token refresh, redirect to login).
// Real business conflicts (e.g. "email already taken") still use BookVerseConflictException -> 409.
public sealed class BookVerseUnauthorizedException : Exception
{
    public BookVerseUnauthorizedException(string message) : base(message) { }
}
