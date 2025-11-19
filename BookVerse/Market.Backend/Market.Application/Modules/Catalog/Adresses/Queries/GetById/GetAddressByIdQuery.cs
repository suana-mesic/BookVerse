using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Adresses.Queries.GetById
{
    public class GetAddressByIdQuery: IRequest<GetAddressByIdQueryDto>
    {
        public int Id { get; set; }
    }
}
