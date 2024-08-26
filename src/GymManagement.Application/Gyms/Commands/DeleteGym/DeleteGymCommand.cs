using ErrorOr;
using MediatR;

namespace GymManagement.Application.Gyms.Commands.DeleteGym;

public record DeleteGymCommand(Guid GymId, Guid SubscriptionId) : IRequest<ErrorOr<Deleted>>;
