using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Create
{
    public class CreateOrderOrderItemsCommandDto
    {
        public int OrderId { get; set; }
        public string ClientSecret { get; set; }
        public string PublishableKey { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
