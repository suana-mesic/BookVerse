namespace BookVerse.Application.Modules.Shopping.Cart.Queries.List;

public class ListCartQuery : IRequest<ListCartQueryDto>
{
    public string? Language { get; set; }
}