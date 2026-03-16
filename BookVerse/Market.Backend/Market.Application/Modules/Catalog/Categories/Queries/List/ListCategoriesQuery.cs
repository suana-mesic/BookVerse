using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Queries.List
{
    public sealed class ListCategoriesQuery : IRequest<List<ListCategoriesQueryDto>>
    {
        public string? Search { get; init; }
    }
}
