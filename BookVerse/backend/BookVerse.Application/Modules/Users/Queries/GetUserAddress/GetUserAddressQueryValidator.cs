namespace BookVerse.Application.Modules.Users.Queries.GetUserAddress;

public sealed class GetUserAddressQueryValidator : AbstractValidator<GetUserAddressQuery>
{
    public GetUserAddressQueryValidator()
    {
        // No input parameters to validate; the user is resolved from the auth context.
    }
}
