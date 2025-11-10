namespace Market.Infrastructure.Database.Configurations.Catelog;

public class StoresConfiguration : IEntityTypeConfiguration<Stores>
{
    public void Configure(EntityTypeBuilder<Stores> builder)
    {
        builder
            .Property(x => x.StoreName)
            .IsRequired()
            .HasMaxLength(Stores.Constraints.StoreNameMaxLength);
        
        builder
           .Property(x => x.Phone)
           .IsRequired()
           .HasMaxLength(Stores.Constraints.PhoneMaxLength);

        builder
          .Property(x => x.Email)
          .IsRequired()
          .HasMaxLength(Stores.Constraints.EmailMaxLength);

        builder
        .Property(x => x.OpeningHours)
        .IsRequired()
        .HasMaxLength(Stores.Constraints.OpeningHoursMaxLength);
    }
}
