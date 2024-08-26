using GymManagement.Application.Common.Interfaces;
using GymManagement.Infrastructure.Admins.Persistence;
using GymManagement.Infrastructure.Common.Persistence;
using GymManagement.Infrastructure.Gyms.Persistence;
using GymManagement.Infrastructure.Subscriptions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Infrastructure;

// make this class 'public' and others 'internal' for
// give reference from 'API' to 'Infrastructure'
// but not access to all codes
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<GymManagementDbContext>(options => options.UseSqlite("Data Source = GymManagement.db"));

        services.AddScoped<ISubscriptionsRepository, SubscriptionsRepository>();
        services.AddScoped<IAdminsRepository, AdminsRepository>();
        services.AddScoped<IGymsRepository, GymsRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<GymManagementDbContext>());

        return services;
    }
}
