using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Gyms;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Gyms.Persistence;

public class GymsRepository(GymManagementDbContext dbContext) : IGymsRepository
{
    public async Task AddGymAsync(Gym gym) => await dbContext.Gym.AddAsync(gym);

    public Task<bool> ExistsAsync(Guid gymId) => dbContext.Gym.AsNoTracking().AnyAsync(g => g.Id == gymId);

    public Task<Gym?> GetByIdAsync(Guid gymId) => dbContext.Gym.AsNoTracking().FirstOrDefaultAsync(g => g.Id == gymId);

    public Task<List<Gym>> ListBySubscriptionIdAsync(Guid subscriptionId) => dbContext.Gym.AsNoTracking().Where(g => g.SubscriptionId == subscriptionId).ToListAsync();

    public Task RemoveGymAsync(Gym gym)
    {
        dbContext.Gym.Remove(gym);
        return Task.CompletedTask;
    }

    public Task RemoveGymAsync(Guid gymId)
    {
        var gym = dbContext.Gym.FirstOrDefault(g => g.Id == gymId) ?? throw new FileNotFoundException("Gym not found.");
        dbContext.Gym.Remove(gym);
        return Task.CompletedTask;
    }

    public Task RemoveRangeAsync(List<Gym> gyms)
    {
        dbContext.Gym.RemoveRange(gyms);
        return Task.CompletedTask;
    }

    public Task RemoveRangeAsync(List<Guid> gymIds)
    {
        var gyms = dbContext.Gym.Where(g => gymIds.Contains(g.Id)) ?? throw new FileNotFoundException("Gym not found.");
        dbContext.Gym.RemoveRange(gyms);
        return Task.CompletedTask;
    }

    public Task UpdateGymAsync(Gym gym)
    {
        dbContext.Update(gym);
        return Task.CompletedTask;
    }
}
