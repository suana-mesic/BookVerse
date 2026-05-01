using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.Cart.Commands.Delete
{
    public class DeleteCartItemCommand : IRequest<string>
    {
        public required int CartId { get; set; }
        public required int BookId { get; set; }
    }
}
