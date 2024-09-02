using GymManagement.Domain.Rooms;

namespace GymManagement.Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(Guid GymId, string RoomName) : IRequest<ErrorOr<Room>>;
