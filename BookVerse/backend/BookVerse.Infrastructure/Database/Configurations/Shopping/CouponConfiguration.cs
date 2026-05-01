using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Infrastructure.Database.Configurations.Shopping;

public class CouponConfiguration : IEntityTypeConfiguration<Coupons>
{
    public void Configure(EntityTypeBuilder<Coupons> builder)
    {
        builder
            .ToTable("Coupons");

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Coupons.Constraints.NameMaxLength);

        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(Coupons.Constraints.DescriptionMaxLength);


        builder
            .Property(x => x.PromotionCode)
            .IsRequired()
            .HasMaxLength(Coupons.Constraints.PromotionCodeMaxLength);


    }
}
