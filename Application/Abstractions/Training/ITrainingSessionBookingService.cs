namespace Application.Abstractions.Training;

public interface ITrainingSessionBookingService
{
    Task<bool> BookAsync(Guid sessionId, string userId);
     Task<bool> CancelBookingAsync(Guid sessionId, string userId);
     Task<IReadOnlySet<Guid>> GetBookingsForUserAsync(string userId);
}
