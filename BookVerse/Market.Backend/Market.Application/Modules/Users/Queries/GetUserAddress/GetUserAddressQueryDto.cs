namespace Market.Application.Modules.Users.Queries.GetUserAddress;

public class GetUserAddressQueryDto
{
    public int? AddressId { get; set; }
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}