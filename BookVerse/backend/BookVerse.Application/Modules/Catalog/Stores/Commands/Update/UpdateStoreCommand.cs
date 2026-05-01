using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Stores.Commands.Update
{
    public sealed class UpdateStoreCommand: IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; } // ID is passed in the route, not in the body!
        public string? StoreName { get; set; }
        public int? AddressId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? OpeningHours { get; set; }
    }
}
