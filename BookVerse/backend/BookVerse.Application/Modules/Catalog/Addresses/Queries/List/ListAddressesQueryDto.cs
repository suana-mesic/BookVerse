using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Addresses.Queries.List;
public sealed class ListAddressesQueryDto
{    
    public int Id { get; set; }
    public string Line1 { get; set; }
    public string? Line2 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}
