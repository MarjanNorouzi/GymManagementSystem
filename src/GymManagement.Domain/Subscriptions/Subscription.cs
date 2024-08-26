using ErrorOr;
using GymManagement.Domain.Gyms;

namespace GymManagement.Domain.Subscriptions;

public class Subscription
{
    private readonly List<Guid> _gymIds = [];
    private readonly int _maxGyms;

    public Subscription(SubscriptionType subscriptionType, Guid adminId, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        AdminId = adminId;
        SubscriptionType = subscriptionType;
        _maxGyms = GetMaxGyms();
    }

    private Subscription()
    { }

    public Guid Id { get; private set; }
    public SubscriptionType SubscriptionType { get; private set; } = null!;
    public Guid AdminId { get; }

    public ErrorOr<Success> AddGym(Gym gym)
    {
        if (_gymIds.Contains(gym.Id)) throw new InvalidOperationException("Subscription already subscribe this gym.");

        if (_gymIds.Count >= _maxGyms) throw new InvalidOperationException("Can't Have More Gyms Than Subscription Allows.");

        _gymIds.Add(gym.Id);

        return Result.Success;
    }

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

    public bool HasGym(Guid gymId) => _gymIds.Contains(gymId);

    public void RemoveGym(Guid gymId)
    {
        if (!_gymIds.Contains(gymId)) throw new InvalidOperationException("Subscription doesn't subscribe this gym.");
    
        _gymIds.Remove(gymId);
    }
}
