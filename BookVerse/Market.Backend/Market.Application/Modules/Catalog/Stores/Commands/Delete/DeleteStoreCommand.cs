using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Stores.Commands.Delete
{
    public class DeleteStoreCommand: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
