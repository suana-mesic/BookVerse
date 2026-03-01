using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Common.Interfaces
{
    public interface IStripeSettings
    {
        string SecretKey { get; }
        string PublishableKey { get; }

        //WebhookSecret je tajni ključ koji Stripe daje, i svaki put kad Stripe pošalje webhook, potpiše poruku tim ključem. Zatim backend provjeri potpis i tek onda vjeruje da je zaista Stripe poslao tu poruku
        string WebhookSecret { get; }
    }
}
