using PartyNL.Domain.Common;

namespace PartyNL.Domain.Entities;

public class Favorite : BaseEntity
{
    public Guid UserId { get; set; }

    public Guid EventId { get; set; }

    public DateTime CreatedAt { get; set; }

    public User User { get; set; } = null!;

    public Event Event { get; set; } = null!;
}