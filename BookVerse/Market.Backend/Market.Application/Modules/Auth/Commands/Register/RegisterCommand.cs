using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Auth.Commands.Register
{
   public class RegisterCommand:IRequest<RegisterCommandDto>
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public string ConfirmedPassword { get; init; }
        public string? Fingerprint { get; init; }
    }
}
