namespace GymManagement.Application.Subscriptions.Commands.DeleteSubscription;

public class DeleteSubscriptionCommandHandler(
    ISubscriptionsRepository subscriptionsRepository,
    IAdminsRepository adminsRepository,
    IGymsRepository gymsRepository,
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

        var gymsToDelete = await gymsRepository.ListBySubscriptionIdAsync(command.SubscriptionId);

        await subscriptionsRepository.RemoveSubscriptionAsync(subscription);
        await adminsRepository.UpdateAsync(admin);
        await gymsRepository.RemoveRangeAsync(gymsToDelete);
        await unitOfWork.CommitChangeAsync();

        return Result.Deleted;
    }
}