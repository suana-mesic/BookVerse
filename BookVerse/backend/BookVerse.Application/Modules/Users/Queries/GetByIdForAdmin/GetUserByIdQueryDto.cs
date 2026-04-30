namespace BookVerse.Application.Modules.Users.Queries.GetByIdForAdmin
{
    public class GetUserByIdQueryDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsEnabled { get; set; }
    }
}
