using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Auth.Commands.Register
{
   public class RegisterCommand:IRequest<RegisterCommandDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Line1 { get; init; }
        public string? Line2 { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
        public string? Fingerprint { get; init; }
    }
}
