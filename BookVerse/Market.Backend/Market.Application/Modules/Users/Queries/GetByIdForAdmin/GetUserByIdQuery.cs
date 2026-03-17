namespace Market.Application.Modules.Users.Queries.GetByIdForAdmin
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQueryDto>
    {
        public int Id { get; set; }
    }
}
