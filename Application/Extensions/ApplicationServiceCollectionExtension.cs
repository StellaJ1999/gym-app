using Application.Abstractions.Support;
using Application.Abstractions.Training;
using Application.Support.Services;
using Application.Training.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.Extensions;

// Denna extension-metod används i Program.cs för att registrera applikationsservice i DI-containern,
public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplication( this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(environment);

        // Registrerar applikationsservice så att MVC-controllern kan injicera IContactRequestService.
        // Utan detta kommer POST att faila eftersom DI inte kan skapa SupportController korrekt.

        services.AddScoped<IContactRequestService, ContactRequestService>();
        services.AddScoped<ITrainingSessionService, TrainingSessionService>();
        services.AddScoped<ITrainingSessionBookingService, TrainingSessionBookingService>();

        return services;
    }
}
