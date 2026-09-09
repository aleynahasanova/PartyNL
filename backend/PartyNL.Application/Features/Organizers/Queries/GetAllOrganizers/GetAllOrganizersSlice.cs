using MediatR;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;

namespace PartyNL.Application.Features.Organizers.Queries.GetAllOrganizers;

public sealed record GetAllOrganizersQuery : IRequest<GetAllOrganizersResponse>;
public sealed record OrganizerResponse(Guid Id, string Name, string? Description, string? Email, string? Phone, string? Website, string? LogoUrl, bool IsVerified);
public sealed record GetAllOrganizersResponse(IEnumerable<OrganizerResponse> Organizers);
public sealed class GetAllOrganizersHandler(IOrganizerRepository repository) : IRequestHandler<GetAllOrganizersQuery, GetAllOrganizersResponse>
{
    public async Task<GetAllOrganizersResponse> Handle(GetAllOrganizersQuery request, CancellationToken cancellationToken)
    {
        var organizers = await repository.GetAllAsync();
        return new(organizers.Select(organizer => new OrganizerResponse(organizer.Id, organizer.Name, organizer.Description, organizer.Email, organizer.Phone, organizer.Website, organizer.LogoUrl, organizer.IsVerified)));
    }
}