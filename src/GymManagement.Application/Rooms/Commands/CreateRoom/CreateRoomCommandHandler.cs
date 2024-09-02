using GymManagement.Domain.Rooms;

namespace GymManagement.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler
    (IGymsRepository gymsRepository, IUnitOfWork unitOfWork, ISubscriptionsRepository subscriptionsRepository)
    : IRequestHandler<CreateRoomCommand, ErrorOr<Room>>
{
    public async Task<ErrorOr<Room>> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
    {
        var gym = await gymsRepository.GetByIdAsync(command.GymId);
        if (gym is null) return Error.NotFound(description: "Gym not found.");


        var subscription = await subscriptionsRepository.GetByIdAsync(gym.SubscriptionId);
        if (subscription is null) return Error.Unexpected(description: "Subscription not found");

        var room = new Room(command.RoomName, command.GymId, subscription.GetMaxDailySessions());

        var addGymResult = gym.AddRoom(room);
        if (addGymResult.IsError) return addGymResult.Errors;

        // The room itself isn't stored in our database

        await gymsRepository.UpdateGymAsync(gym);
        await unitOfWork.CommitChangeAsync();

        return room;
    }
}
