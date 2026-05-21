using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Common.Interfaces
{
    // Central place for "which status transitions are allowed?". Replaces the ad-hoc
    // status checks scattered across CreateOrderOrderItemsCommandHandler,
    // StripeWebhookCommandHandler and CancelOrderCommandHandler. Also writes the
    // companion timestamps (PaidAt, CancelledAt) so they can't drift from the status.
    public interface IOrderStateMachine
    {
        // Returns true when the transition from the order's current status to the target
        // status is allowed. Pure check, no side effects.
        bool CanTransition(Orders order, OrderStatusType target);

        // Throws BookVerseConflictException if the transition is not allowed.
        void EnsureCanTransition(Orders order, OrderStatusType target);

        // Validates AND applies the transition: updates OrderStatusId and the matching
        // timestamp (PaidAt for Paid, CancelledAt for Cancelled). Does not call SaveChanges.
        void Transition(Orders order, OrderStatusType target);
    }
}
