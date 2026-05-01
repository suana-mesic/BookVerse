using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Infrastructure.Database.Configurations.Shopping;

public class ShippingUpdateConfiguration : IEntityTypeConfiguration<ShippingUpdates>
{
    public void Configure(EntityTypeBuilder<ShippingUpdates> builder)
    {
        builder
            .ToTable("ShippingUpdates");

        builder
            .Property(x => x.Notes)
            .IsRequired()
            .HasMaxLength(ShippingUpdates.Constraints.NotesMaxLength);


    }
}
