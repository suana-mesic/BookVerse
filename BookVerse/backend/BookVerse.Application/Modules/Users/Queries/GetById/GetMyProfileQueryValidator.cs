namespace BookVerse.Application.Modules.Users.Queries.GetById;

public sealed class GetMyProfileQueryValidator : AbstractValidator<GetMyProfileQuery>
{
    public GetMyProfileQueryValidator()
    {
        // No input parameters to validate; the user is resolved from the auth context.
    }
}
