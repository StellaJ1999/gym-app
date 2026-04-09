using Domain.Training;

namespace Presentation.WebApp.Models;

public sealed record TrainingSessionListItemViewModel(
    TrainingSession Session,
    bool IsBooked,
    int BookedCount,
    bool IsFull
);
