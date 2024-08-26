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
        Name = name;
        _maxRooms = maxRooms;
        SubscriptionId = subscriptionId;
        Id = id ?? Guid.NewGuid();
    }

    private Gym() { }

    //public ErrorOr<Success> AddRoom(Room room)
    //{

    //    _roomIds.Add(room.Id);

    //    return Result.Success;
    //}
    public void RemoveRoom(Guid roomId) => _roomIds.Remove(roomId);
    public void HasRoom(Guid roomId) => _roomIds.Contains(roomId);

    //public ErrorOr<Success> AddTrainer() { }
    public void RemoveTrainer(Guid trainerId) => _trainerIds.Remove(trainerId);
    public void HasTrainer(Guid trainerId) => _trainerIds.Contains(trainerId);

}
