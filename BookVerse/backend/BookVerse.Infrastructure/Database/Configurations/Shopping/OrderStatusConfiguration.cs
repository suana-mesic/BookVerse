using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Infrastructure.Database.Configurations.Shopping;

public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder
           .ToTable("OrderStatus");

        builder
            .Property(x => x.StatusName)
            .IsRequired()
            .HasMaxLength(OrderStatus.Constraints.StatusNameMaxLength);
    }
}
