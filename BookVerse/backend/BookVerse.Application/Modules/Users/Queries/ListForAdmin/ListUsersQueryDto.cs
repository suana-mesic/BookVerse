namespace BookVerse.Application.Modules.Users.Queries.ListForAdmin
{
    public class ListUsersQueryDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsEnabled { get; set; }
    }
}
