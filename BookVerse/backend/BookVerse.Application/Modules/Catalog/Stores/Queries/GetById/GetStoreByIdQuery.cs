using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Stores.Queries.GetById
{
    public class GetStoreByIdQuery: IRequest<GetStoreByIdQueryDto>
    {
        public int Id { get; set; }
    }
}
