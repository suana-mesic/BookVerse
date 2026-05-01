using BookVerse.Application.Modules.Auth.Commands.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Auth.Commands.VerifyTwoFactor
{
    public sealed class VerifyTwoFactorCommand: IRequest<LoginCommandDto>
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
