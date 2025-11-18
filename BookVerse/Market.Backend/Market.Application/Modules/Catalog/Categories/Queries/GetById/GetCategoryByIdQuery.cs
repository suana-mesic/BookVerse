using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Queries.GetById
{
    public sealed class GetCategoryByIdQuery: IRequest<GetCategoryByIdQueryDto>
    {
         public int Id { get; set; }
    }
}
