using Market.Domain.Entities.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Queries.List
{
    public class ListInventoryQueryDto
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime LastRestocked { get; set; }
        public int ReorderTreshold { get; set; }
        public string? Location { get; set; }
        public int? QuantityInStockForOnlineOrders { get; set; }
    }
}
