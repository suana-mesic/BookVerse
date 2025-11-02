using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Catalog
{
    public class BookFormats: BaseEntity
    {
        public string Format { get; set; }
    }
}
