using Domain.Training;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public sealed class TrainingSessionBookingConfiguration
{
    public void Configure(EntityTypeBuilder<TrainingSessionBooking> builder)
    {
        builder.ToTable("TrainingSessionBookings");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId).IsRequired().HasMaxLength(450);
        builder.Property(x => x.BookedAtUtc).IsRequired();
        builder.Property(x => x.TrainingSessionId).IsRequired();

        //Förhindra dubbelbokning av samma användare för samma träningspass
        builder.HasIndex(x => new { x.UserId, x.TrainingSessionId }).IsUnique();
        builder.HasIndex(x => x.UserId);
    }
}
