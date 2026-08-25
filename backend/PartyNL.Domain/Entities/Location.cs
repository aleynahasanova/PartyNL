using PartyNL.Domain.Common;

namespace PartyNL.Domain.Entities;

public class Location : AuditableEntity
{
    public string? Name { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Province { get; set; }

    public string? Country { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public ICollection<Event> Events { get; set; } = new List<Event>();
}