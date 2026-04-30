using BookVerse.Application.Modules.Reviews.Queries.GetById;

namespace BookVerse.Tests.ReviewsTests.UnitTests;

public class GetReviewsByIdQueryValidatorUnitTests
{
    private readonly GetReviewsByIdQueryValidator _validator = new();

    [Fact]
    public void Validate_WithPositiveBookId_ShouldNotHaveErrors()
    {
        var query = new GetReviewsByIdQuery { BookId = 1 };

        var result = _validator.Validate(query);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Validate_WithZeroBookId_ShouldHaveError()
    {
        var query = new GetReviewsByIdQuery { BookId = 0 };

        var result = _validator.Validate(query);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(query.BookId));
    }

    [Fact]
    public void Validate_WithNegativeBookId_ShouldHaveError()
    {
        var query = new GetReviewsByIdQuery { BookId = -10 };

        var result = _validator.Validate(query);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(query.BookId));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(999999)]
    public void Validate_WithVariousPositiveIds_ShouldBeValid(int bookId)
    {
        var query = new GetReviewsByIdQuery { BookId = bookId };

        var result = _validator.Validate(query);

        Assert.True(result.IsValid);
    }
}
