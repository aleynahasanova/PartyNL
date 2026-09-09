using MediatR;
using PartyNL.Application.Abstractions.Repositories;

namespace PartyNL.Application.Features.Organizers.Commands.DeleteOrganizer;

public sealed record DeleteOrganizerCommand(Guid Id) : IRequest<DeleteOrganizerResponse>;
public sealed record DeleteOrganizerResponse(Guid Id);
public sealed class DeleteOrganizerHandler(IOrganizerRepository repository) : IRequestHandler<DeleteOrganizerCommand, DeleteOrganizerResponse>
{
    public async Task<DeleteOrganizerResponse> Handle(DeleteOrganizerCommand request, CancellationToken cancellationToken)
    {
        var organizer = await repository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException($"Organizer with ID '{request.Id}' was not found.");
        await repository.DeleteAsync(organizer);
        return new(organizer.Id);
    }
}