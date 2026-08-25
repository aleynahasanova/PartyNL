using PartyNL.Domain.Entities;
using PartyNL.Domain.Enums;

namespace PartyNL.Domain.Entities;

public class Attendance
{
    public Guid UserId { get; set; }

    public Guid EventId { get; set; }

    public AttendanceStatus Status { get; set; }

    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = null!;

    public Event Event { get; set; } = null!;
}