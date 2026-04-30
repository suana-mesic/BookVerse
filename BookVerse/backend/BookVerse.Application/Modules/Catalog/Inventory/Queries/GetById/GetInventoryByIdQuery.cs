using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Inventory.Queries.GetById
{
    public class GetInventoryByIdQuery:IRequest<GetInventoryByIdQueryDto>
    {
        public int StoreId { get; set; }
        public int BookId { get; set; }
    }
}
