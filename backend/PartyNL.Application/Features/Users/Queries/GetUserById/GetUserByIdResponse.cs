namespace PartyNL.Application.Features.Users.Queries.GetUserById;

public sealed record GetUserByIdResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email
);