using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Common.Services
{
    // Implementation of IOrderStateMachine. One central table of allowed transitions
    // replaces the ad-hoc "if status != X return" guards that used to live in the
    // order handlers. TimeProvider is injected so PaidAt / CancelledAt come from the
    // same clock that the handlers use - unit tests can pin time deterministically.
    public sealed class OrderStateMachine(TimeProvider time) : IOrderStateMachine
    {
        // Allowed transitions for the order lifecycle.
        //   Draft           -> PaymentPending (PaymentIntent created)
        //                   -> Paid           (free order, total = 0)
        //                   -> PaymentFailed  (webhook reported payment failed)
        //                   -> Cancelled      (user cancelled before payment)
        //                   -> Expired        (cleanup sweep)
        //   PaymentPending  -> Paid           (webhook reported success)
        //                   -> PaymentFailed  (webhook reported failure)
        //                   -> Cancelled      (user abandoned checkout)
        //                   -> Expired        (cleanup sweep)
        //   Paid            -> Packed         (staff workflow)
        //                   -> Cancelled      (customer-initiated refund)
        //   Packed          -> Shipped        (staff workflow)
        //                   -> Cancelled      (customer-initiated refund)
        //   Shipped, Cancelled, PaymentFailed, Expired = terminal.
        private static readonly Dictionary<OrderStatusType, OrderStatusType[]> AllowedTransitions = new()
        {
            { OrderStatusType.Draft,           new[] { OrderStatusType.PaymentPending, OrderStatusType.Paid, OrderStatusType.PaymentFailed, OrderStatusType.Cancelled, OrderStatusType.Expired } },
            { OrderStatusType.PaymentPending,  new[] { OrderStatusType.Paid, OrderStatusType.PaymentFailed, OrderStatusType.Cancelled, OrderStatusType.Expired } },
            { OrderStatusType.Paid,            new[] { OrderStatusType.Packed, OrderStatusType.Cancelled } },
            { OrderStatusType.Packed,          new[] { OrderStatusType.Shipped, OrderStatusType.Cancelled } },
            { OrderStatusType.Shipped,         Array.Empty<OrderStatusType>() },
            { OrderStatusType.Cancelled,       Array.Empty<OrderStatusType>() },
            { OrderStatusType.PaymentFailed,   Array.Empty<OrderStatusType>() },
            { OrderStatusType.Expired,         Array.Empty<OrderStatusType>() }
        };

        public bool CanTransition(Orders order, OrderStatusType target)
        {
            var current = (OrderStatusType)order.OrderStatusId;
            return AllowedTransitions.TryGetValue(current, out var allowed) && allowed.Contains(target);
        }

        public void EnsureCanTransition(Orders order, OrderStatusType target)
        {
            if (!CanTransition(order, target))
            {
                var current = (OrderStatusType)order.OrderStatusId;
                throw new BookVerseConflictException(
                    $"Invalid order status transition from {current} to {target}.");
            }
        }

        public void Transition(Orders order, OrderStatusType target)
        {
            EnsureCanTransition(order, target);

            order.OrderStatusId = (int)target;

            // Set the timestamp that goes with each terminal-payment status so it never
            // drifts from the status itself. Uses TimeProvider so tests can control "now".
            var nowUtc = time.GetUtcNow().UtcDateTime;
            if (target == OrderStatusType.Paid)
                order.PaidAt = nowUtc;
            else if (target == OrderStatusType.Cancelled)
                order.CancelledAt = nowUtc;
        }
    }
}
