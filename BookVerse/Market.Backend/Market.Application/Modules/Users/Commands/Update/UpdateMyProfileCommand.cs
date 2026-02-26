namespace Market.Application.Modules.Users.Commands.UpdateMyProfile;

public sealed class UpdateMyProfileCommand : IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Line1 { get; set; }
    public string? Line2 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public bool TwoFactorEnabled { get; set; }
}