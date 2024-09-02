using GymManagement.Domain.Gyms;

namespace GymManagement.Application.Gyms.Queries.GetGym;

public class GetGymQueryHandler(
    IGymsRepository gymsRepository,
    ISubscriptionsRepository subscriptionsRepository) : IRequestHandler<GetGymQuery, ErrorOr<Gym>>
{
    public async Task<ErrorOr<Gym>> Handle(GetGymQuery request, CancellationToken cancellationToken)
    {
        if (await subscriptionsRepository.ExistsAsync(request.SubscriptionId))
            return Error.NotFound(description: "Subscription not found.");

        if (await gymsRepository.GetByIdAsync(request.GymId) is not Gym gym)
            return Error.NotFound(description: "Gym not found");

        return gym;
    }
}
