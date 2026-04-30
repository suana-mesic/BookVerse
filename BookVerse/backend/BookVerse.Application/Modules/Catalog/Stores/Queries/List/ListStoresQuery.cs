using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Stores.Queries.List
{
    public sealed class ListStoresQuery: BasePagedQuery<ListStoresQueryDto>
    {
        public string? Search { get; init; }
        public bool? OnlyEnabled { get; init; }
    }
}
