using GymManagement.Domain.Gyms;

namespace GymManagement.Application.Gyms.Commands.CreateGym;

public class CreateGymCommandHandler(
    IGymsRepository gymsRepository,
    ISubscriptionsRepository subscriptionsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateGymCommand, ErrorOr<Gym>>
{
    public async Task<ErrorOr<Gym>> Handle(CreateGymCommand command, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionsRepository.GetByIdAsync(command.SubscriptionId);
        if (subscription == null) return Error.NotFound(description: "Subscription not found.");

        var gym = new Gym(command.Name, subscription.GetMaxRooms(), subscription.Id);

        var addGymResult = subscription.AddGym(gym);
        if (addGymResult.IsError) return addGymResult.Errors;

        await subscriptionsRepository.UpdateAsync(subscription);
        await gymsRepository.AddGymAsync(gym);
        await unitOfWork.CommitChangeAsync();

        return gym;
    }
}
