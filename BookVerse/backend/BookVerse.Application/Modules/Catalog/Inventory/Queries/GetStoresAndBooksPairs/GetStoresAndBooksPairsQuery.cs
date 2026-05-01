using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Inventory.Queries.GetStoresAndBooksPairs
{
    public class GetStoresAndBooksPairsQuery:IRequest<Dictionary<int, Dictionary<int,string>>>
    {
    }
}
