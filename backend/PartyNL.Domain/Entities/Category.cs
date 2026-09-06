using PartyNL.Domain.Common;

namespace PartyNL.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Icon { get; set; }

    public ICollection<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
}