namespace BookVerse.Application.Common.Exceptions;

public sealed class BookVerseNotFoundException : Exception
{
    public BookVerseNotFoundException(string message) : base(message) { }
}
