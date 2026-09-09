using MediatR;
using PartyNL.Application.Abstractions.Repositories;

namespace PartyNL.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserByIdResponse> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            throw new KeyNotFoundException($"User with ID '{request.UserId}' was not found.");
        }

        return new GetUserByIdResponse(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email
        );
    }
}