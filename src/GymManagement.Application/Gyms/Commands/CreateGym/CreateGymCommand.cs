using GymManagement.Domain.Gyms;

namespace GymManagement.Application.Gyms.Commands.CreateGym;

public record CreateGymCommand(Guid SubscriptionId, string Name) : IRequest<ErrorOr<Gym>>;
