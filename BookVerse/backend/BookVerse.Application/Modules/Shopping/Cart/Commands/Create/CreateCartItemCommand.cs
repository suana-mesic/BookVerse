using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.Cart.Commands.Create
{
    // The command no longer returns a string. Response shape (status code, body) is the API layer's
    // job, so the handler returns Unit and the controller answers with 204 NoContent.
    public class CreateCartItemCommand:IRequest<Unit>
    {
        public int BookId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
