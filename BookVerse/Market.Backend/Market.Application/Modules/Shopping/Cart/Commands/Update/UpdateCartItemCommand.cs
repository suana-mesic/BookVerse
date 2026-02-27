namespace Market.Application.Modules.Shopping.Cart.Commands.Update;

public class UpdateCartItemCommand : IRequest<string>
{
    public required int CartId { get; set; }
    public required int BookId { get; set; }
    public required int Quantity { get; set; }
}