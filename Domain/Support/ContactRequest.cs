namespace Domain.Support;

public class ContactRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string Message { get; set; } = null!;

    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}