using Application.Abstractions.Training;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Training.Services
{
    internal class TrainingSessionBookingService(ITrainingSessionRepository sessionsRepo, ITrainingSessionBookingRepository bookingsRepo) : ITrainingSessionBookingService
    {
        public async Task<bool> BookAsync(Guid sessionId, string userId)
        {
            if(string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User ID is required.", nameof(userId));

            // Kolla om sessionen finns
            var session = await sessionsRepo.GetByIdAsync(sessionId);
            if (session is null)
                return false;

            // Kolla om sessionen är fullbokad
            if (session.Bookings.Any(x => x.UserId == userId))
                return false;

            //Kolla om användaren redan har en bokning för den här sessionen
            if (session.Bookings.Count >= session.MaxParticipants)
                return false;

            return await bookingsRepo.AddAsync(sessionId, userId);

        }

        public Task<bool> CancelBookingAsync(Guid sessionId, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User ID is required.", nameof(userId));

                return bookingsRepo.RemoveAsync(sessionId, userId);
        }

        public Task<IReadOnlySet<Guid>> GetBookingsForUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("UserId is required.", nameof(userId));

            return bookingsRepo.GetBookedSessionIdsAsync(userId);
        }
    }
}
