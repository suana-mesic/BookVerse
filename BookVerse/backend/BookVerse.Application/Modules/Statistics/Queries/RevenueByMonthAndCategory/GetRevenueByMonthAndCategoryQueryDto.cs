using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Statistics.Queries.RevenueByMonthAndCategory
{
    public class GetRevenueByMonthAndCategoryQueryDto
    {
        public int Month { get; set; }
        public string MonthName { get; set; }
        public string CategoryName { get; set; }
        public decimal Revenue { get; set; }
    }
}
