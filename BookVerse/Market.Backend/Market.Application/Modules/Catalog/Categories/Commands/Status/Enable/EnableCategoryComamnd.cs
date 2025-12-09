using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Commands.Status.Enable
{
    public class EnableCategoryComamnd: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
