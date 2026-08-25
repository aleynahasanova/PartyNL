using PartyNL.Domain.Common;

namespace PartyNL.Domain.Entities;

public class Organizer : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public string? LogoUrl { get; set; }
    public bool IsVerified { get; set; }

    public ICollection<Event> Events { get; set; } = new List<Event>();
}