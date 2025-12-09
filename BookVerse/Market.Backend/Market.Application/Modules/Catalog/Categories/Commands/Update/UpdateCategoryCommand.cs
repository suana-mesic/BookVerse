using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Commands.Update
{
    public sealed class UpdateCategoryCommand: IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool isEnabled { get; set; }
    }
}
