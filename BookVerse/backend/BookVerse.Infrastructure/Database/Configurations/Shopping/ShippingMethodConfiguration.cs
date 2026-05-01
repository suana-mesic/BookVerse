using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Infrastructure.Database.Configurations.Shopping;

public class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethods>
{
    public void Configure(EntityTypeBuilder<ShippingMethods> builder)
    {
        builder
            .ToTable("ShippingMethods");

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(ShippingMethods.Constraints.NameMaxLength);

        builder
           .Property(x => x.Description)
           .IsRequired()
           .HasMaxLength(ShippingMethods.Constraints.DescriptionMaxLength);
    }
}
