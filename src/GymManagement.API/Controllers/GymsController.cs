using GymManagement.Application.Gyms.Commands.CreateGym;
using GymManagement.Application.Gyms.Commands.DeleteGym;
using GymManagement.Application.Gyms.Queries.GetGym;
using GymManagement.Application.Gyms.Queries.ListGyms;
using GymManagement.Contracts.Gyms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.API.Controllers;


[ApiController]
[Route("subscriptions/{subscriptionId:guid}/gyms")]
public class GymsController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGym(CreateGymRequest request, Guid subscriptionId)
    {
        var command = new CreateGymCommand(subscriptionId, request.Name);

        var result = await sender.Send(command);

        return result.Match(
            Ok,
            _ => Problem());
    }

    [HttpDelete("{gymId:Guid}")]
    public async Task<IActionResult> DeleteGym(Guid subscriptionId, Guid gymId)
    {
        var command = new DeleteGymCommand(gymId, subscriptionId);
        var result = await sender.Send(command);
        return result.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem());
    }

    [HttpGet]
    public async Task<IActionResult> ListGyms(Guid subscriptionId)
    {
        var query = new ListGymsQuery(subscriptionId);
        var result = await sender.Send(query);
        return result.Match(
            g => Ok(g.Select(x => new GymResponse(x.Id, x.Name))),
            _ => Problem());
    }

    [HttpGet("{gymId:Guid}")]
    public async Task<IActionResult> GetGym(Guid subscriptionId, Guid gymId)
    {
        var query = new GetGymQuery(subscriptionId, gymId);
        var result = await sender.Send(query);
        return result.Match(
            g => Ok(new GymResponse(g.Id, g.Name)),
            _ => Problem());
    }
}
