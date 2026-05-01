namespace BookVerse.Infrastructure.Database.Configurations.Catalog;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder
            .Property(x => x.StoreName)
            .IsRequired()
            .HasMaxLength(Store.Constraints.StoreNameMaxLength);
        
        builder
           .Property(x => x.Phone)
           .IsRequired()
           .HasMaxLength(Store.Constraints.PhoneMaxLength);

        builder
          .Property(x => x.Email)
          .IsRequired()
          .HasMaxLength(Store.Constraints.EmailMaxLength);

        builder
        .Property(x => x.OpeningHours)
        .IsRequired()
        .HasMaxLength(Store.Constraints.OpeningHoursMaxLength);
    }
}
