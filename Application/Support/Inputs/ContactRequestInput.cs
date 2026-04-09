namespace Application.Support.Inputs;

// Denna record används som input när en användare skickar in en kontaktförfrågan via ett formulär på webbplatsen.
// Den innehåller de fält som användaren fyller i,
// samt Id och CreatedAt som sätts av applikationslagret för att säkerställa att dessa alltid är korrekt ifyllda när de sparas i databasen.
public sealed record ContactRequestInput
(
    string FirstName,
    string LastName,
    string Email,
    string? Phone,
    string Message
)
{
    public string Id { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }

    public void SetId(string id) => Id = id;
    public void SetDate(DateTime createdAt) => CreatedAt = createdAt;
}