using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Auth.Commands.Register
{
    public class RegisterCommandDto
    {
        public int UserId { get; set; }

        /// <summary>
        /// JWT access token – used for authorized API calls.
        /// </summary>
        public string? AccessToken { get; set; }

        /// <summary>
        /// Refresh token that the client stores locally and uses to obtain a new access token.
        /// </summary>
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Expiration time of the access token in UTC format.
        /// </summary>
        public DateTime? ExpiresAtUtc { get; set; }
    }
}
