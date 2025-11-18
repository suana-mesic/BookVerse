using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Commands.Delete
{
    public class DeleteCategoryCommand: IRequest<Unit>
    {
        public required int Id { get; set; }
    }
}

//namespace Market.Application.Modules.Catalog.ProductCategories.Commands.Delete;

//public class DeleteProductCategoryCommand : IRequest<Unit>
//{
//    public required int Id { get; set; }
//}
