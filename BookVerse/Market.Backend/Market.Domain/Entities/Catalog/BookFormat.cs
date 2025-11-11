using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Catalog
{
    public class BookFormat : BaseEntity
    {
        public string Format { get; set; }
        public static class Constraints
        {
            public const int FormatMaxLength = 50;
        }
    }
}
