using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

// Den här filen är en ren databas-mappning för EF Core.
// Den finns i Infrastructure eftersom tabellnamn, fältlängder och index är persistensdetaljer.
public sealed class ContactRequestConfiguration : IEntityTypeConfiguration<ContactRequest>
{
    public void Configure(EntityTypeBuilder<ContactRequest> builder)
    {
        // Vi mappar ContactRequest-klassen till en tabell som heter "ContactRequests".
        builder.ToTable("ContactRequests");

        // Vi kan specificera fältlängder, index och andra databasdetaljer här.
        builder.HasKey(x => x.Id);


        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Phone).HasMaxLength(50);
        builder.Property(x => x.Message).IsRequired();
        builder.Property(x => x.CreatedUtc).IsRequired();

        // Index hjälper när du listar många rader, eller senare söker/filterar i en adminvy.
        builder.HasIndex(x => x.CreatedUtc);
        builder.HasIndex(x => x.Email);
    }
}
