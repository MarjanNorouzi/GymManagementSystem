using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController(
    // we can use 'IMediator' but better to use smaller interfaces 
    ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(), request.AdminId);
        var subscriptionId = await sender.Send(command);
        var response = new CreateSubscriptionResponse(subscriptionId, request.SubscriptionType);

        return Ok(response);
    }
}
