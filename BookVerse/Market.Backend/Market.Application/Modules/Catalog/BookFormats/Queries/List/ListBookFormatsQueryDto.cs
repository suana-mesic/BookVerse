using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.BookFormats.Queries.List
{
    public class ListBookFormatsQueryDto
    {
        public int Id { get; set; }
        public string Format { get; set; }
        public bool IsDeleted { get; set; }
    }
}
