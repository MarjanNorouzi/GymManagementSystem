using GymManagement.Domain.Subscriptions;

namespace GymManagement.Domain.Admins;

public class Admin
{
    public Guid Id { get; }
    public Guid UserId { get; private set; }
    public Guid? SubscriptionId { get; private set; } = null;

    public Admin(Guid userId, Guid? subscriptionId, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        UserId = userId;
        SubscriptionId = subscriptionId;
    }

    private Admin()
    { }

    public void SetSubscription(Subscription subscription)
    {
        if (SubscriptionId.HasValue) throw new Exception("Admin already has an active subscription.");
        SubscriptionId = subscription.Id;
    }

    public void DeleteSubscription(Guid subscriptionId)
    {
        if (SubscriptionId is null) throw new Exception("Admin hasn't any active subscription.");
        if (SubscriptionId == subscriptionId) throw new Exception("Subscription is not available for this admin.");
        SubscriptionId = null;
    }
}
