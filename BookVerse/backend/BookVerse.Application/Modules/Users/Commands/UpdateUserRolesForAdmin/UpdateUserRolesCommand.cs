namespace BookVerse.Application.Modules.Users.Commands.UpdateUserRolesForAdmin
{
    public class UpdateUserRolesCommand:IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsEnabled { get; set; }
    }
}
