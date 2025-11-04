using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Catalog
{
    public class Categories: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Books> Books { get; set; } = new List<Books>();
    }
}
