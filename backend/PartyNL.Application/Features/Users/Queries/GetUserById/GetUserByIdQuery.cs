using MediatR;

namespace PartyNL.Application.Features.Users.Queries.GetUserById;
public sealed record GetUserByIdQuery(Guid UserId): IRequest<GetUserByIdResponse>;
