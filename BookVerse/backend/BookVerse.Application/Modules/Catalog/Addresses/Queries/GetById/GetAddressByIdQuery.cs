using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Addresses.Queries.GetById
{
    public class GetAddressByIdQuery: IRequest<GetAddressByIdQueryDto>
    {
        public int Id { get; set; }
    }
}
