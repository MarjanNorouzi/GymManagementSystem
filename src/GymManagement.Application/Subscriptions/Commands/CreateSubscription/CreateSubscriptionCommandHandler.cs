using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler(
    ISubscriptionsRepository subscriptionsRepository,
    IAdminsRepository adminsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand command, CancellationToken cancellationToken)
    {
        var admin = await adminsRepository.GetByIdAsync(command.AdminId);

        if (admin is null)
            return Error.NotFound(description: "Admin not found.");

        // create a subscription
        var subscription = new Subscription(
            subscriptionType: command.SubscriptionType,
            adminId: command.AdminId);

        if (admin.SubscriptionId is not null)
            return Error.Conflict(description: "Admin already has an active subscription.");

        admin.SetSubscription(subscription);

        // add to database
        await subscriptionsRepository.AddSubscriptionAsync(subscription);
        await adminsRepository.UpdateAsync(admin);
        await unitOfWork.CommitChangeAsync();

        // return result
        return subscription;
    }
}
