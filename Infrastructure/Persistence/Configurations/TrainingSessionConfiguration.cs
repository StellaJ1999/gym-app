using Domain.Training;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public sealed class TrainingSessionConfiguration
{
    public void Configure(EntityTypeBuilder<TrainingSession> builder)
    {
        builder.ToTable("TrainingSessions");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Date).HasMaxLength(1000);
        builder.Property(x => x.StartTime).IsRequired();
        builder.Property(x => x.EndTime).IsRequired();
        builder.Property(x => x.MaxParticipants).IsRequired();
        builder.Property(x => x.CreatedUtc).IsRequired();
        builder.HasIndex(x => x.StartTime);

        // Konfigurera relationen mellan TrainingSession och TrainingSessionBooking

        builder.HasMany(x => x.Bookings)
               .WithOne(b => b.TrainingSession)
               .HasForeignKey(b => b.TrainingSessionId)
               .OnDelete(DeleteBehavior.Cascade); // När en TrainingSession tas bort, ta bort relaterade TrainingSessionBookings

        // Indexering för snabbare sökningar
        builder.HasIndex(x => x.StartTime);
        builder.HasIndex(x => x.Date); 
    }
}
