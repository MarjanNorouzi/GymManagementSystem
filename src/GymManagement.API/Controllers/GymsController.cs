﻿using GymManagement.Application.Gyms.Commands.AddTrainer;
using GymManagement.Application.Gyms.Commands.CreateGym;
using GymManagement.Application.Gyms.Commands.DeleteGym;
using GymManagement.Application.Gyms.Queries.GetGym;
using GymManagement.Application.Gyms.Queries.ListGyms;
using GymManagement.Contracts.Gyms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.API.Controllers;

[ApiController]
[Route("subscriptions/{subscriptionId:guid}/gyms/")]
public class GymsController(ISender sender) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateGym(CreateGymRequest request, Guid subscriptionId)
    {
        var command = new CreateGymCommand(subscriptionId, request.Name);

        var result = await sender.Send(command);

        return result.Match(
            gym => CreatedAtAction(nameof(GetGym), new { subscriptionId, gym.Id }, new GymResponse(gym.Id, gym.Name)),
            Problem);
    }

    [HttpDelete("{gymId:Guid}")]
    public async Task<IActionResult> DeleteGym(Guid subscriptionId, Guid gymId)
    {
        var command = new DeleteGymCommand(gymId, subscriptionId);
        var result = await sender.Send(command);
        return result.Match<IActionResult>(
            _ => NoContent(),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListGyms(Guid subscriptionId)
    {
        var query = new ListGymsQuery(subscriptionId);
        var result = await sender.Send(query);
        return result.Match(
            g => Ok(g.Select(x => new GymResponse(x.Id, x.Name))),
           Problem);
    }

    [HttpGet("{gymId:Guid}")]
    public async Task<IActionResult> GetGym(Guid subscriptionId, Guid gymId)
    {
        var query = new GetGymQuery(subscriptionId, gymId);
        var result = await sender.Send(query);
        return result.Match(
            g => Ok(new GymResponse(g.Id, g.Name)),
            Problem);
    }

    [HttpPost("{gymId:Guid}/trainers")]
    public async Task<IActionResult> AddTrainer(AddTrainerRequest request, Guid subscriptionId, Guid gymId)
    {
        var command = new AddTrainerCommand(subscriptionId, gymId, request.TrainerId);

        var result = await sender.Send(command);

        return result.MatchFirst(
            success => Ok(),
            Problem);
    }
}
