namespace Market.Application.Modules.Shopping.Cart.Commands.SaveForLater;

public class SaveForLaterCommand : IRequest<string>
{
    public required int CartId { get; set; }
    public required int BookId { get; set; }
    public required bool SavedForLater { get; set; }
}