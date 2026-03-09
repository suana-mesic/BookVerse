using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Statistics.Queries.CategoriesPopularity
{
    public class GetCategoriesPopularityQueryDto
    {
        public string GenreName { get; set; }
        public int TotalSold { get; set; }
    }
}
