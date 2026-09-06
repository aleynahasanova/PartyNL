using PartyNL.Domain.Common;

namespace PartyNL.Domain.Entities;

public class EventCategory : BaseEntity
{
    public Guid EventId { get; set; }

    public Guid CategoryId { get; set; }

    public Event Event { get; set; } = null!;

    public Category Category { get; set; } = null!;
}