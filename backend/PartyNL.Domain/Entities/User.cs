namespace PartyNL.Domain.Entities;
using PartyNL.Domain.Common;

public class User : AuditableEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string? ProfilePictureUrl { get; set; }

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}