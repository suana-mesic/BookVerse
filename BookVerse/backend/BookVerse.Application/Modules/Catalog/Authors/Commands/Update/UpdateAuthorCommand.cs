using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Authors.Commands.Update;
    public sealed class UpdateAuthorCommand:IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Biography { get; set; }
    public string? Country { get; set; }
}
