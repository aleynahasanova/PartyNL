using MediatR;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;

namespace PartyNL.Application.Features.Organizers.Commands.UpdateOrganizer;

public sealed record UpdateOrganizerCommand(Guid Id, string Name, string? Description, string? Email, string? Phone, string? Website, string? LogoUrl, bool IsVerified) : IRequest<UpdateOrganizerResponse>;
public sealed record UpdateOrganizerResponse(Guid Id, string Name, string? Description, string? Email, string? Phone, string? Website, string? LogoUrl, bool IsVerified);

public sealed class UpdateOrganizerHandler(IOrganizerRepository repository) : IRequestHandler<UpdateOrganizerCommand, UpdateOrganizerResponse>
{
    public async Task<UpdateOrganizerResponse> Handle(UpdateOrganizerCommand request, CancellationToken cancellationToken)
    {
        var organizer = await repository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException($"Organizer with ID '{request.Id}' was not found.");
        organizer.Name = request.Name; organizer.Description = request.Description; organizer.Email = request.Email; organizer.Phone = request.Phone; organizer.Website = request.Website; organizer.LogoUrl = request.LogoUrl; organizer.IsVerified = request.IsVerified;
        await repository.UpdateAsync(organizer);
        return new(organizer.Id, organizer.Name, organizer.Description, organizer.Email, organizer.Phone, organizer.Website, organizer.LogoUrl, organizer.IsVerified);
    }
}