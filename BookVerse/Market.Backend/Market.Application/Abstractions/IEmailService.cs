using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Abstractions
{
    public interface IEmailService
    {
        Task SendTwoFactorCodeAsync(string toEmail, string code, CancellationToken ct = default);
    }
}
