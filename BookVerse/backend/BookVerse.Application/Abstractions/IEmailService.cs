using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Abstractions
{
    public interface IEmailService
    {
        Task SendTwoFactorCodeAsync(string toEmail, string code, CancellationToken ct = default);
        Task SendPasswordResetAsync(string toEmail, string resetLink, CancellationToken ct = default);
    }
}
