using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Statistics.Queries.CategoriesPopularity
{
    public class GetCategoriesPopularityQuery:IRequest<List<GetCategoriesPopularityQueryDto>>
    {
        public string? Language { get; set; }
    }
}
