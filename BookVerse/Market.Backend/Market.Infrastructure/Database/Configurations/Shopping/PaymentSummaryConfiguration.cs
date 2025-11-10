using Market.Domain.Entities.Shopping;

namespace Market.Infrastructure.Database.Configurations.Shopping;

public class PaymentSummaryConfiguration : IEntityTypeConfiguration<PaymentSummaries>
{
    public void Configure(EntityTypeBuilder<PaymentSummaries> builder)
    {
        builder
            .ToTable("PaymentSummaries");

        builder
            .Property(x => x.Brand)
            .IsRequired()
            .HasMaxLength(PaymentSummaries.Constraints.BrandMaxLength);

    }
}
