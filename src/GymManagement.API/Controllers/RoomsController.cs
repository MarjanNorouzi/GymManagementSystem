using GymManagement.Application.Rooms.Commands.CreateRoom;
using GymManagement.Application.Rooms.Commands.DeleteRoom;
using GymManagement.Contracts.Rooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("gyms/{gymId:guid}/rooms")]
public class RoomsController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRoom(CreateRoomRequest request, Guid gymId)
    {
        var command = new CreateRoomCommand(gymId, request.Name);

        var createRoomResult = await sender.Send(command);

        return createRoomResult.Match(
            room => Created($"rooms/{room.Id}", new RoomResponse(room.Id, room.Name)),
            _ => Problem());
    }

    [HttpDelete("{roomId:Guid}")]
    public async Task<IActionResult> DeleteRoom(Guid gymId, Guid roomId)
    {
        var command = new DeleteRoomCommand(gymId, roomId);

        var deleteRoomResult = await sender.Send(command);

        return deleteRoomResult.Match<IActionResult>(
            _ => NoContent(),
            _ => Problem());
    }
}