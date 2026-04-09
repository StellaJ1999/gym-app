using Application.Abstractions.Training;
using Application.Training.Inputs;
using Domain.Training;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

internal class TrainingSessionRepository(PersistenceContext db) : ITrainingSessionRepository
{
    public async Task<bool> CreateTrainingSessionAsync(TrainingSessionInput model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var entity = new TrainingSession
        {
            Id = model.Id == default ? Guid.NewGuid() : model.Id,
            Name = model.Name,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            Date = model.StartTime.Date,
            MaxParticipants = model.MaxParticipants,
            CreatedUtc = model.CreatedUtc == default ? DateTime.UtcNow : model.CreatedUtc

        };

        db.TrainingSessions.Add(entity);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteTrainingSessionAsync(Guid sessionId)
    {
        var entity = await db.TrainingSessions.FirstOrDefaultAsync(x => x.Id == sessionId);
        if (entity is null)
            return false;

        db.TrainingSessions.Remove(entity);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<IReadOnlyList<TrainingSession>> GetAllAsync()
    {
        return await db.TrainingSessions
            .Include(x => x.Bookings)
            .AsNoTracking()
            .OrderBy(x => x.StartTime)
            .ToListAsync();
    }

    public async Task<TrainingSession?> GetByIdAsync(Guid id)
    {
        return await db.TrainingSessions
                        .Include(x => x.Bookings)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateTrainingSessionAsync(TrainingSessionInput model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var entity = await db.TrainingSessions.FirstOrDefaultAsync(x => x.Id == model.Id);
        if (entity is null)
            return false;

        entity.Name = model.Name;
        entity.StartTime = model.StartTime;
        entity.EndTime = model.EndTime;
        entity.Date = model.StartTime.Date;
        entity.MaxParticipants = model.MaxParticipants;

        return await db.SaveChangesAsync() > 0;
    }
}
