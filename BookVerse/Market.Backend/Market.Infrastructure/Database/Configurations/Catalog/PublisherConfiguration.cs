namespace Market.Infrastructure.Database.Configurations.Catalog;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Publisher.Constraints.NameMaxLength);

        builder
             .Property(x => x.City)
             .IsRequired()
             .HasMaxLength(Publisher.Constraints.CityMaxLength);

        builder
         .Property(x => x.Country)
         .IsRequired()
         .HasMaxLength(Publisher.Constraints.CountryMaxLength);
    }
}
