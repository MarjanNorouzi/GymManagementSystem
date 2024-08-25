using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.DeleteSubscription;

public class DeleteSubscriptionCommandHandler(
    ISubscriptionsRepository subscriptionsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteSubscriptionCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteSubscriptionCommand command, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionsRepository.GetByIdAsync(command.SubscriptionId);

        if (subscription == null)
            return Error.NotFound(description: "Subscription not found");

        await subscriptionsRepository.RemoveSubscriptionAsync(subscription);
        await unitOfWork.CommitChangeAsync();

        return Result.Deleted;
    }
}