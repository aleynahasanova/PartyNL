using MediatR;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;

namespace PartyNL.Application.Features.Organizers.Commands.CreateOrganizer;

public sealed record CreateOrganizerCommand(string Name, string? Description, string? Email, string? Phone, string? Website, string? LogoUrl, bool IsVerified) : IRequest<CreateOrganizerResponse>;
public sealed record CreateOrganizerResponse(Guid Id, string Name, string? Description, string? Email, string? Phone, string? Website, string? LogoUrl, bool IsVerified);

public sealed class CreateOrganizerHandler(IOrganizerRepository repository) : IRequestHandler<CreateOrganizerCommand, CreateOrganizerResponse>
{
    public async Task<CreateOrganizerResponse> Handle(CreateOrganizerCommand request, CancellationToken cancellationToken)
    {
        var organizer = new Organizer { Name = request.Name, Description = request.Description, Email = request.Email, Phone = request.Phone, Website = request.Website, LogoUrl = request.LogoUrl, IsVerified = request.IsVerified };
        await repository.AddAsync(organizer);
        return Map(organizer);
    }

    private static CreateOrganizerResponse Map(Organizer organizer) => new(organizer.Id, organizer.Name, organizer.Description, organizer.Email, organizer.Phone, organizer.Website, organizer.LogoUrl, organizer.IsVerified);
}