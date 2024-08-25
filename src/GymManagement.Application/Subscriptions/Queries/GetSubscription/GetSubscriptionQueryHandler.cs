using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscription;

public class GetSubscriptionQueryHandler(ISubscriptionsRepository subscriptionsRepository) : IRequestHandler<GetSubscriptionQuery, ErrorOr<Subscription>>
{
    public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuery query, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionsRepository.GetByIdAsync(query.SubscriptionId);

        return subscription == null 
            ? (ErrorOr<Subscription>)Error.NotFound("Subscriotion not found.") 
            : (ErrorOr<Subscription>)subscription;
    }
}
