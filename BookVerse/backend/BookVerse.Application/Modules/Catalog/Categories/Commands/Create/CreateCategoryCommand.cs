using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Categories.Commands.Create
{
    public class CreateCategoryCommand: IRequest<int>
    {
        public required string Name { get; set; }
    }
}

