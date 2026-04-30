using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Common.Interfaces
{
    public interface IStripeSettings
    {
        string SecretKey { get; }
        string PublishableKey { get; }

        //WebhookSecret is the secret key provided by Stripe; every time Stripe sends a webhook, it signs the message with this key. The backend then verifies the signature and only then trusts that the message was truly sent by Stripe
        string WebhookSecret { get; }
    }
}
