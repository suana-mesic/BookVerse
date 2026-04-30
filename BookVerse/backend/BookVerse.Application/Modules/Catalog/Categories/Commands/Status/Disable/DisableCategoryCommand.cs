using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Categories.Commands.Status.Disable
{
    public class DisableCategoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
