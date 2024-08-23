namespace GymManagement.Application.Services;

public interface ISubscriptionsService
{
    public Guid CreateSubscription(string SubscriptionType, Guid adminId);
}
