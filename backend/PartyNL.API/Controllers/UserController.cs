using MediatR;
using Microsoft.AspNetCore.Mvc;
using PartyNL.Application.Features.Users.Queries.GetUserById;

namespace PartyNL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetUserByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetUserByIdResponse>> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetUserByIdQuery(id));

        return Ok(response);
    }
}