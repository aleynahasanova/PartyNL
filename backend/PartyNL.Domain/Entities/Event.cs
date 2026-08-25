using PartyNL.Domain.Common;
using PartyNL.Domain.Enums;

namespace PartyNL.Domain.Entities;

public class Event : AuditableEntity
{
    public Guid OrganizerId { get; set; }

    public Guid LocationId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public int Capacity { get; set; }

    public int MinimumAge { get; set; }

    public EventVisibility Visibility { get; set; }

    public EventStatus Status { get; set; }

    public string? CoverImageUrl { get; set; }

    // Navigation Properties
    public Organizer Organizer { get; set; } = null!;

    public Location Location { get; set; } = null!;

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}