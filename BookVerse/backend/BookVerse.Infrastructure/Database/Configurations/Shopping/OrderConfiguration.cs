using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Infrastructure.Database.Configurations.Shopping;

public class OrderConfiguration : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder
            .ToTable("Orders");

        builder
            .Property(x => x.TrackingNumber)
            .IsRequired()
            .HasMaxLength(Orders.Constraints.TrackingNumberMaxLength);

    }
}
