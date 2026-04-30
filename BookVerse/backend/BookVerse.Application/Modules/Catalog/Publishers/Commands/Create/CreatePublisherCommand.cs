using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Publishers.Commands.Create
{
    public class CreatePublisherCommand: IRequest<int>
    {
        public required string Name { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
    }
}
