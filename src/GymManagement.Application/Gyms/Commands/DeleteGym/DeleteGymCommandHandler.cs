using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using MediatR;

namespace GymManagement.Application.Gyms.Commands.DeleteGym;

public class DeleteGymCommandHandler(
    IGymsRepository gymsRepository,
    ISubscriptionsRepository subscriptionsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteGymCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteGymCommand command, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionsRepository.GetByIdAsync(command.SubscriptionId);
        if (subscription == null) return Error.NotFound(description: "Subscription not found.");

        // can do this in repository
        //var gym = await gymsRepository.GetByIdAsync(command.GymId);
        //if (gym == null) return Error.NotFound(description: "Gym not found.");

        subscription.RemoveGym(command.GymId);

        await subscriptionsRepository.UpdateAsync(subscription);
        await gymsRepository.RemoveGymAsync(command.GymId);
        await unitOfWork.CommitChangeAsync();

        return Result.Deleted;
    }
}
