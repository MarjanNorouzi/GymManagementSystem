using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Commands.DeleteSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainSubscriptionType = GymManagement.Domain.Subscriptions.SubscriptionType;

namespace GymManagement.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController(
    // we can use 'IMediator' but better to use smaller interfaces 
    ISender sender) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        if (!DomainSubscriptionType.TryFromName(request.SubscriptionType.ToString(), out var subscriptionType))
            return Problem(detail: "Invalid SubscriptionType", statusCode: StatusCodes.Status400BadRequest);

        var command = new CreateSubscriptionCommand(subscriptionType, request.AdminId);

        var result = await sender.Send(command);

        return result.MatchFirst(subscription =>
        Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
        Problem);
    }

    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscription(Guid subscriptionId)
    {
        var query = new GetSubscriptionQuery(subscriptionId);

        var result = await sender.Send(query);

        return result.MatchFirst(subscription =>
        Ok(new SubscriptionResponse(subscription.Id, ToDto(subscription.SubscriptionType))),
        Problem);
    }

    [HttpDelete("{subscriptionId:guid}")]
    public async Task<IActionResult> DeleteSubscription(Guid subscriptionId)
    {
        var result = await sender.Send(new DeleteSubscriptionCommand(subscriptionId));

        return result.Match<IActionResult>(
            _ => NoContent(),
            Problem);
    }

    private static SubscriptionType ToDto(DomainSubscriptionType subscriptionType)
    {
        return subscriptionType.Name switch
        {
            nameof(DomainSubscriptionType.Free) => SubscriptionType.Free,
            nameof(DomainSubscriptionType.Starter) => SubscriptionType.Starter,
            nameof(DomainSubscriptionType.Pro) => SubscriptionType.Pro,
            _ => throw new InvalidOperationException(),
        };
    }
}
