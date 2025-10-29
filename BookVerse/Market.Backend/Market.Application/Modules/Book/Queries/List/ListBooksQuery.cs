using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Book.Queries.List;

    public sealed class ListBooksQuery: BasePagedQuery<ListBooksQueryDto>
    {
        public string? Search { get; init; }
        public bool? OnlyEnabled { get; init; }
    }
