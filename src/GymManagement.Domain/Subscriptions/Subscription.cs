namespace GymManagement.Domain.Subscriptions;

public class Subscription
{
    private readonly Guid _adminId;

    public Subscription(SubscriptionType subscriptionType, Guid adminId, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        _adminId = adminId;
        SubscriptionType = subscriptionType;
    }

    // we will use these in project so we don't make them 'private fields'
    public Guid Id { get; private set; }

    public SubscriptionType SubscriptionType { get; private set; }

    private Subscription()
    { }
}
