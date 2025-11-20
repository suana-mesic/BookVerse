using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Stores.Commands.Update
{
    public sealed class UpdateStoreCommand: IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; } // ID se prosleđuje u ruti, a ne u body-ju!
        public string? StoreName { get; set; }
        public int? AddressId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? OpeningHours { get; set; }
    }
}
