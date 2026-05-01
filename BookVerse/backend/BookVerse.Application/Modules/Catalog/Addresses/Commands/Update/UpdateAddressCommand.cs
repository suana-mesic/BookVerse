using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Addresses.Commands.Update
{
    public class UpdateAddressCommand: IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
