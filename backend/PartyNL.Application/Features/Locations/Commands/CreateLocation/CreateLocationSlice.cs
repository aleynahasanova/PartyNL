using MediatR;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;

namespace PartyNL.Application.Features.Locations.Commands.CreateLocation;

public sealed record CreateLocationCommand(string? Name, string? Street, string? City, string? PostalCode, string? Province, string? Country, decimal Latitude, decimal Longitude) : IRequest<CreateLocationResponse>;
public sealed record CreateLocationResponse(Guid Id, string? Name, string? Street, string? City, string? PostalCode, string? Province, string? Country, decimal Latitude, decimal Longitude);
public sealed class CreateLocationHandler(ILocationRepository repository) : IRequestHandler<CreateLocationCommand, CreateLocationResponse>
{
    public async Task<CreateLocationResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = new Location { Name = request.Name, Street = request.Street, City = request.City, PostalCode = request.PostalCode, Province = request.Province, Country = request.Country, Latitude = request.Latitude, Longitude = request.Longitude };
        await repository.AddAsync(location);
        return new(location.Id, location.Name, location.Street, location.City, location.PostalCode, location.Province, location.Country, location.Latitude, location.Longitude);
    }
}