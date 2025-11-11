namespace Market.Infrastructure.Database.Configurations.Catalog;

public class PublisherConfiguration : IEntityTypeConfiguration<Publishers>
{
    public void Configure(EntityTypeBuilder<Publishers> builder)
    {
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Publishers.Constraints.NameMaxLength);

        builder
             .Property(x => x.City)
             .IsRequired()
             .HasMaxLength(Publishers.Constraints.CityMaxLength);

        builder
         .Property(x => x.Country)
         .IsRequired()
         .HasMaxLength(Publishers.Constraints.CountryMaxLength);
    }
}
