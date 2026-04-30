using BookVerse.Application.Modules.Reviews.Commands.Create;

namespace BookVerse.Tests.ReviewsTests.UnitTests;

public class CreateReviewValidatorUnitTests
{
    private readonly CreateReviewCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var command = new CreateReviewCommand { BookId = 1, Rating = 5, Comment = "Excellent book!" };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(6)]
    [InlineData(-1)]
    public void Validate_WithInvalidRating_ShouldHaveRatingError(int rating)
    {
        var command = new CreateReviewCommand { BookId = 1, Rating = rating, Comment = "Comment" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Rating));
    }

    [Fact]
    public void Validate_WithEmptyComment_ShouldHaveCommentError()
    {
        var command = new CreateReviewCommand { BookId = 1, Rating = 3, Comment = "" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Comment));
    }

    [Fact]
    public void Validate_WithTooLongComment_ShouldHaveCommentError()
    {
        var command = new CreateReviewCommand { BookId = 1, Rating = 3, Comment = new string('x', 2001) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Comment));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    public void Validate_WithBoundaryRatings_ShouldBeValid(int rating)
    {
        var command = new CreateReviewCommand { BookId = 1, Rating = rating, Comment = "Comment" };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
    }
}
