
namespace Application.Support.Outputs;
// Output-modeller är de modeller som applikationen returnerar till presentations-lagret,
// till exempel MVC-controllers eller API-endpoints.
// De är ofta "read-only" och kan innehålla mer eller mindre data än de entiteter som används i Domain-lagret,
// beroende på vad som är relevant för konsumenten.
public sealed record ContactRequest
(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    string? Phone,
    string Message,
    DateTime CreatedAt
);
