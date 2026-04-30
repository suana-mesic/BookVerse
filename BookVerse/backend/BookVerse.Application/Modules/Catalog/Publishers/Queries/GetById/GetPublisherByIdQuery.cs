using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Publishers.Queries.GetById
{
    public class GetPublisherByIdQuery: IRequest<GetPublisherByIdQueryDto>
    {
        public int Id { get; set; }
    }
}
