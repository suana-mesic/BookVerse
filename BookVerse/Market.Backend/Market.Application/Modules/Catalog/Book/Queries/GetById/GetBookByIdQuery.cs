namespace Market.Application.Modules.Catalog.Book.Queries.GetById;

public class GetBookByIdQuery : IRequest<GetBookByIdQueryDto>
{
    public int Id { get; set; }
    public string? Language { get; set; }
}