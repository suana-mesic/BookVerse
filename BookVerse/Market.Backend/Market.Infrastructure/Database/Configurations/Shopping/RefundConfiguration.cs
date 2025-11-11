using Market.Domain.Entities.Shopping;

namespace Market.Infrastructure.Database.Configurations.Shopping;

public class RefundConfiguration : IEntityTypeConfiguration<Refunds>
{
    public void Configure(EntityTypeBuilder<Refunds> builder)
    {
        builder
            .ToTable("Refunds");

        builder
            .Property(x => x.Status)
            .IsRequired()
            .HasMaxLength(Refunds.Constraints.StatusMaxLength);

        builder
           .Property(x => x.Reason)
           .IsRequired()
           .HasMaxLength(Refunds.Constraints.ReasonMaxLength);

    }
}
