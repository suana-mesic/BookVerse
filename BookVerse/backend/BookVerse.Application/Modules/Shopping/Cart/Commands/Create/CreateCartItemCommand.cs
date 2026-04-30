using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.Cart.Commands.Create
{
    public class CreateCartItemCommand:IRequest<string>
    {
        public int BookId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
