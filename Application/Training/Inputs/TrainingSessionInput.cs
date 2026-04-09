namespace Application.Training.Inputs;

public sealed record TrainingSessionInput 
(
    string Name,
    DateTime StartTime,
    DateTime EndTime,
    int MaxParticipants
)
{
    public Guid Id { get; private set; }
    public DateTime CreatedUtc { get; private set; } // För att kunna sätta dessa värden i repositoryt så behöver vi privata set; på dem, annars kan vi inte ändra dem efter att objektet skapats.

    public void SetId(Guid id) => Id = id;
    public void SetCreatedUtc(DateTime createdUtc) => CreatedUtc = createdUtc;
}
