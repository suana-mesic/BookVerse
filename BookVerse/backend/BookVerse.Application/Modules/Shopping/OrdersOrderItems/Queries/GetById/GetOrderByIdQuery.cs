using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.GetById
{
    public class GetOrderByIdQuery:IRequest<GetOrderByIdQueryDto>
    {
        public int Id { get; set; }
    }
}
