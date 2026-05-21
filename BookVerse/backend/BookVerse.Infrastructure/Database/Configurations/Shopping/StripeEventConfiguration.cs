using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Infrastructure.Database.Configurations.Shopping;

public class StripeEventConfiguration : IEntityTypeConfiguration<StripeEvent>
{
    public void Configure(EntityTypeBuilder<StripeEvent> builder)
    {
        builder.ToTable("StripeEvents");

        builder
            .Property(x => x.StripeEventId)
            .IsRequired()
            .HasMaxLength(StripeEvent.Constraints.StripeEventIdMaxLength);

        builder
            .Property(x => x.EventType)
            .IsRequired()
            .HasMaxLength(StripeEvent.Constraints.EventTypeMaxLength);

        //Unique index ensures a redelivered Stripe event can never be inserted twice; the second attempt
        //is rejected by SQL Server with a duplicate-key exception which the handler treats as "already processed".
        builder
            .HasIndex(x => x.StripeEventId)
            .IsUnique();
    }
}
