using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Adresses.Commands.Delete
{
    public class DeleteAddressCommand: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
