using PartyNL.Domain.Common;

namespace PartyNL.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Icon { get; set; }
}