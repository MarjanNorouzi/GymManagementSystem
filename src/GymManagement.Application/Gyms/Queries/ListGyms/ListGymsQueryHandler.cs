using GymManagement.Domain.Gyms;

namespace GymManagement.Application.Gyms.Queries.ListGyms;

public class ListGymsQueryHandler(
    IGymsRepository gymsRepository,
    ISubscriptionsRepository subscriptionsRepository) : IRequestHandler<ListGymsQuery, ErrorOr<List<Gym>>>
{
    public async Task<ErrorOr<List<Gym>>> Handle(ListGymsQuery request, CancellationToken cancellationToken)
    {
        if (!await subscriptionsRepository.ExistsAsync(request.SubscriptionId))
            return Error.NotFound(description: "Subscription not found.");

        return await gymsRepository.ListBySubscriptionIdAsync(request.SubscriptionId);
    }
}
