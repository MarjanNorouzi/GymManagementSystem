using ErrorOr;

namespace GymManagement.Domain.Subscriptions;

public static class SubscriptionErrors
{
    public static readonly Error CannotHaveMoreGymsThanTheSubscriptionAllows = Error.Validation(
        code: "Subscription.CannotHaveMoreGymsThanTheSubscriptionAllows",
        description: "A Subscription Can't Have More Gyms Than Subscription Allows.");
}