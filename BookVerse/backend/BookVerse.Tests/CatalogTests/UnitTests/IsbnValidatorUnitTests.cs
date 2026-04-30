using BookVerse.Application.Common;

namespace BookVerse.Tests.CatalogTests.UnitTests;

public class IsbnValidatorUnitTests
{
    [Theory]
    [InlineData("9780306406157")]
    [InlineData("9781234567897")]
    [InlineData("9780141439518")]
    public void IsValid_WithValidIsbn13_ReturnsTrue(string isbn)
    {
        Assert.True(IsbnValidator.IsValid(isbn));
    }

    [Theory]
    [InlineData("0306406152")]
    [InlineData("0140449116")]
    public void IsValid_WithValidIsbn10_ReturnsTrue(string isbn)
    {
        Assert.True(IsbnValidator.IsValid(isbn));
    }

    [Theory]
    [InlineData("978-0-306-40615-7")]
    [InlineData("0-306-40615-2")]
    public void IsValid_WithDashesAndSpaces_StillValidates(string isbn)
    {
        Assert.True(IsbnValidator.IsValid(isbn));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void IsValid_WithNullOrEmpty_ReturnsFalse(string? isbn)
    {
        Assert.False(IsbnValidator.IsValid(isbn));
    }

    [Theory]
    [InlineData("9780306406158")]
    [InlineData("0306406153")]
    [InlineData("1234567890")]
    public void IsValid_WithInvalidCheckDigit_ReturnsFalse(string isbn)
    {
        Assert.False(IsbnValidator.IsValid(isbn));
    }

    [Theory]
    [InlineData("12345")]
    [InlineData("978030640615712345")]
    [InlineData("abcdefghij")]
    public void IsValid_WithWrongLength_ReturnsFalse(string isbn)
    {
        Assert.False(IsbnValidator.IsValid(isbn));
    }
}
