using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PartyNL.Domain.Entities;

namespace PartyNL.Persistence.Configurations;

public class OrganizerConfiguration : IEntityTypeConfiguration<Organizer>
{
    public void Configure(EntityTypeBuilder<Organizer> builder)
    {
        builder.ToTable("Organizers");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(o => o.Description)
            .HasMaxLength(2000);

        builder.Property(o => o.Email)
            .HasMaxLength(255);

        builder.Property(o => o.Phone)
            .HasMaxLength(50);

        builder.Property(o => o.Website)
            .HasMaxLength(500);

        builder.Property(o => o.LogoUrl)
            .HasMaxLength(500);

        builder.Property(o => o.IsVerified)
            .IsRequired();
    }
}