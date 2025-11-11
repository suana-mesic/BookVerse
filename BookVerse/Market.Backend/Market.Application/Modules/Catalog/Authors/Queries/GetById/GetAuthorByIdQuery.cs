using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Authors.Queries.GetById;

    public sealed class GetAuthorByIdQuery: IRequest<GetAuthorByIdQueryDto>
    {
        public int Id { get; set; }
    }

