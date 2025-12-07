using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.BookFormats.Queries.List
{
   public class ListBookFormatsQuery: BasePagedQuery<ListBookFormatsQueryDto>
    {
        public string? Search { get; init; }
    }
}
