using ErrorOr;
using GymManagement.Domain.Rooms;

namespace GymManagement.Domain.Gyms;

public class Gym
{
    private readonly int _maxRooms;
    private readonly List<Guid> _roomIds = new();
    private readonly List<Guid> _trainerIds = new();

    public Guid Id { get; }

    public string Name { get; init; } = null!;

    public Guid SubscriptionId { get; init; }

    public Gym(string name, int maxRooms, Guid subscriptionId, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        _maxRooms = maxRooms;
        SubscriptionId = subscriptionId;
    }

    private Gym() { }

    public ErrorOr<Success> AddRoom(Room room)
    {
        if (_roomIds.Contains(room.Id)) throw new Exception("Gym already has this room.");
        if (_roomIds.Count >= _maxRooms) throw new Exception("A gym cannot have more rooms than the subscription allows.");

        _roomIds.Add(room.Id);

        return Result.Success;
    }

    public void RemoveRoom(Guid roomId) => _roomIds.Remove(roomId);

    public bool HasRoom(Guid roomId) => _roomIds.Contains(roomId);

    public ErrorOr<Success> AddTrainer(Guid trainerId)
    {
        if (_trainerIds.Contains(trainerId)) throw new Exception("Trainer already added to gym.");

        _trainerIds.Add(trainerId);

        return Result.Success;
    }

    public void RemoveTrainer(Guid trainerId) => _trainerIds.Remove(trainerId);

    public bool HasTrainer(Guid trainerId) => _trainerIds.Contains(trainerId);
}
