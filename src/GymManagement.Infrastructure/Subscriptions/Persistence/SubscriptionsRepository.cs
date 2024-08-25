using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionsRepository(GymManagementDbContext dbContext) : ISubscriptionsRepository
{
    public async Task AddSubscriptionAsync(Subscription subscription) =>
        await dbContext.Subscription.AddAsync(subscription);

    public async Task<bool> ExistsAsync(Guid id) =>
        await dbContext.Subscription
        .AsNoTracking()
        .AnyAsync(x => x.Id == id);

    public async Task<Subscription?> GetByAdminIdAsync(Guid adminId) =>
        await dbContext.Subscription
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.AdminId == adminId);

    public async Task<Subscription?> GetByIdAsync(Guid id) =>
        await dbContext.Subscription
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Subscription>> ListAsync() =>
        await dbContext.Subscription
        .AsNoTracking()
        .ToListAsync();

    public Task RemoveSubscriptionAsync(Subscription subscription)
    {
        dbContext.Subscription.Remove(subscription);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Subscription subscription)
    {
        dbContext.Subscription.Update(subscription);
        return Task.CompletedTask;
    }
}
