using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Admins;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Admins.Persistence;

public class AdminsRepository(GymManagementDbContext dbContext) : IAdminsRepository
{
    public Task<Admin?> GetByIdAsync(Guid adminId) => 
        dbContext.Admin
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == adminId);

    public Task UpdateAsync(Admin admin)
    {
        dbContext.Admin.Update(admin);
        return Task.CompletedTask;
    }
}