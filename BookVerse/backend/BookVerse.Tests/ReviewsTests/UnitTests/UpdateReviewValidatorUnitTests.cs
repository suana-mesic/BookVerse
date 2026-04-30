using BookVerse.Application.Modules.Reviews.Commands.Update;

namespace BookVerse.Tests.ReviewsTests.UnitTests;

public class UpdateReviewValidatorUnitTests
{
    private readonly UpdateReviewCommandValidator _validator = new();

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveErrors()
    {
        var command = new UpdateReviewCommand { BookId = 1, Rating = 4, Comment = "Updated comment." };

        var result = _validator.Validate(command);

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(6)]
    public void Validate_WithInvalidRating_ShouldHaveRatingError(int rating)
    {
        var command = new UpdateReviewCommand { BookId = 1, Rating = rating, Comment = "Comment" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Rating));
    }

    [Fact]
    public void Validate_WithEmptyComment_ShouldHaveCommentError()
    {
        var command = new UpdateReviewCommand { BookId = 1, Rating = 3, Comment = "" };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Comment));
    }

    [Fact]
    public void Validate_WithTooLongComment_ShouldHaveCommentError()
    {
        var command = new UpdateReviewCommand { BookId = 1, Rating = 3, Comment = new string('a', 2001) };

        var result = _validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.Comment));
    }
}
