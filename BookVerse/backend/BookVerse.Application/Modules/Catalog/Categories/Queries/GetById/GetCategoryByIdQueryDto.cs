using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Categories.Queries.GetById
{
    public sealed class GetCategoryByIdQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isEnabled { get; set; }
    }
}
