namespace GymManagement.Domain.Subscriptions;

public class Subscription
{
    private readonly int _maxGyms;
    public Subscription(SubscriptionType subscriptionType, Guid adminId, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        AdminId = adminId;
        SubscriptionType = subscriptionType;
        _maxGyms = 1;
    }

    private Subscription()
    { }

    public Guid Id { get; private set; }
    public SubscriptionType SubscriptionType { get; private set; } = null!;
    public Guid AdminId { get; }

    public int GetMaxGyms() => (SubscriptionType.Name) switch
    {
        nameof(SubscriptionType.Free) => 1,
        nameof(SubscriptionType.Starter) => 1,
        nameof(SubscriptionType.Pro) => 3,
        _ => throw new InvalidOperationException()
    };

    public int GetMaxRooms() => (SubscriptionType.Name) switch
    {
        nameof(SubscriptionType.Free) => 1,
        nameof(SubscriptionType.Starter) => 3,
        nameof(SubscriptionType.Pro) => int.MaxValue,
        _ => throw new InvalidOperationException()
    };

    public int GetMaxDailySessions() => SubscriptionType.Name switch
    {
        nameof(SubscriptionType.Free) => 4,
        nameof(SubscriptionType.Starter) => int.MaxValue,
        nameof(SubscriptionType.Pro) => int.MaxValue,
        _ => throw new InvalidOperationException()
    };
}
