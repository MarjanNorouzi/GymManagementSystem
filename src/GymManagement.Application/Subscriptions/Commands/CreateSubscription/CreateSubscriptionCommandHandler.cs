using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler(
    ISubscriptionsRepository subscriptionsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand command, CancellationToken cancellationToken)
    {
        // create a subscription
        var subscription = new Subscription
        {
            Id = Guid.NewGuid(),
            SubscriptionType = command.SubscriptionType
        };

        // add to database
        await subscriptionsRepository.AddSubscriptionAsync(subscription);
        await unitOfWork.CommitChangeAsync();

        // return result
        return subscription;
    }
}
