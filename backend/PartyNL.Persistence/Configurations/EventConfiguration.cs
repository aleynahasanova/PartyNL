using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PartyNL.Domain.Entities;

namespace PartyNL.Persistence.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Description)
            .HasMaxLength(3000);

        builder.Property(e => e.Price)
            .HasPrecision(10, 2);

        builder.Property(e => e.CoverImageUrl)
            .HasMaxLength(500);

        builder.Property(e => e.Visibility)
            .HasConversion<string>();

        builder.Property(e => e.Status)
            .HasConversion<string>();

        // Relationship: Event -> Organizer
        builder.HasOne(e => e.Organizer)
            .WithMany(o => o.Events)
            .HasForeignKey(e => e.OrganizerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relationship: Event -> Location
        builder.HasOne(e => e.Location)
            .WithMany(l => l.Events)
            .HasForeignKey(e => e.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}