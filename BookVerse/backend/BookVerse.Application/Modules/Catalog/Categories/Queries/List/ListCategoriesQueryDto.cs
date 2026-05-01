using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Categories.Queries.List
{
    public sealed class ListCategoriesQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isEnabled { get; set; }
    }
}
