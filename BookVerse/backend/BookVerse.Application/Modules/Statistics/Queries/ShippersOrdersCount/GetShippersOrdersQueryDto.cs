using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Statistics.Queries.ShippersOrdersCount
{
    public class GetShippersOrdersQueryDto
    {
        public string ShipperName { get; set; }
        public int OrdersCount { get; set; }
    }
}
