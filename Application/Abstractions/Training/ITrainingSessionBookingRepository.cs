namespace Application.Abstractions.Training;

public interface ITrainingSessionBookingRepository
{
    Task<bool> AddAsync(Guid sessionId, string userId);
    Task<bool> RemoveAsync(Guid sessionId, string userId);
    Task<IReadOnlySet<Guid>> GetBookedSessionIdsAsync(string userId);
}