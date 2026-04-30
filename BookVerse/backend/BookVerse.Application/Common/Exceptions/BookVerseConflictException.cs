namespace BookVerse.Application.Common.Exceptions;

public sealed class BookVerseConflictException : Exception
{
    public BookVerseConflictException(string message) : base(message) { }
}
