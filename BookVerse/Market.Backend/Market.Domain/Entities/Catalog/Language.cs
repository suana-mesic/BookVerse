using Market.Domain.Common;

namespace Market.Domain.Entities.Catalog
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Books> Books { get; set; } = new List<Books>();

        public static class Constraints
        {
            public const int NameMaxLength = 60;
        }
    }
}
