using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Authors.Commands.Create
{
    public class CreateAuthorCommand: IRequest<int>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Biography { get; set; }
        public required string Country { get; set; }
    }
}
