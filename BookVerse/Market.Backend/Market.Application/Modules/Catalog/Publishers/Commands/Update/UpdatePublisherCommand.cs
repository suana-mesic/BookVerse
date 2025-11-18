using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Publishers.Commands.Update
{
    public sealed class UpdatePublisherCommand: IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
    }
}
