using GymManagement.Application.Services;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController(ISubscriptionsService subscriptionsService) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateSubscription(CreateSubscriptionRequest request)
    {
        var id = subscriptionsService.CreateSubscription(request.SubscriptionType.ToString(), request.AdminId);

        var response = new CreateSubscriptionResponse(id, request.SubscriptionType);

        return Ok(response);
    }
}
