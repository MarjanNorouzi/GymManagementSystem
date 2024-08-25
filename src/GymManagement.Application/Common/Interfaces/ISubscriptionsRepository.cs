using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Common.Interfaces;

public interface ISubscriptionsRepository
{
    Task AddSubscriptionAsync(Subscription subscription);

    Task<Subscription?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task<Subscription?> GetByAdminIdAsync(Guid adminId);

    Task<List<Subscription>> ListAsync();

    Task RemoveSubscriptionAsync(Subscription subscription);

    Task UpdateAsync(Subscription subscription);
}
