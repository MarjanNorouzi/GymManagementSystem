using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Infrastructure;

// make this class 'public' and others 'internal' for
// give reference from 'API' to 'Infrastructure'
// but not access to all codes
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}
