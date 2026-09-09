using MediatR;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;

namespace PartyNL.Application.Features.Organizers.Queries.GetOrganizerById;

public sealed record GetOrganizerByIdQuery(Guid OrganizerId) : IRequest<GetOrganizerByIdResponse>;
public sealed record GetOrganizerByIdResponse(Guid Id, string Name, string? Description, string? Email, string? Phone, string? Website, string? LogoUrl, bool IsVerified);
public sealed class GetOrganizerByIdHandler(IOrganizerRepository repository) : IRequestHandler<GetOrganizerByIdQuery, GetOrganizerByIdResponse>
{
    public async Task<GetOrganizerByIdResponse> Handle(GetOrganizerByIdQuery request, CancellationToken cancellationToken)
    {
        var organizer = await repository.GetByIdAsync(request.OrganizerId) ?? throw new KeyNotFoundException($"Organizer with ID '{request.OrganizerId}' was not found.");
        return new(organizer.Id, organizer.Name, organizer.Description, organizer.Email, organizer.Phone, organizer.Website, organizer.LogoUrl, organizer.IsVerified);
    }
}