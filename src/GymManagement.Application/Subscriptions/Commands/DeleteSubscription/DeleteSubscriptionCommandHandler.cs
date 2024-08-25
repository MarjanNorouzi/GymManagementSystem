using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.DeleteSubscription;

public class DeleteSubscriptionCommandHandler(
    ISubscriptionsRepository subscriptionsRepository,
    IAdminsRepository adminsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteSubscriptionCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteSubscriptionCommand command, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionsRepository.GetByIdAsync(command.SubscriptionId);

        if (subscription is null)
            return Error.NotFound(description: "Subscription not found.");

        var admin = await adminsRepository.GetByIdAsync(subscription.AdminId);

        if (admin is null)
            return Error.NotFound(description: "Admin not found.");

        admin.DeleteSubscription(command.SubscriptionId);

        await subscriptionsRepository.RemoveSubscriptionAsync(subscription);
        await adminsRepository.UpdateAsync(admin);
        await unitOfWork.CommitChangeAsync();

        return Result.Deleted;
    }
}