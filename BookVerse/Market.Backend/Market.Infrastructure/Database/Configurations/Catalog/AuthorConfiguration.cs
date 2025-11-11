namespace Market.Infrastructure.Database.Configurations.Catalog;

public class AuthorConfiguration : IEntityTypeConfiguration<Authors>
{
    public void Configure(EntityTypeBuilder<Authors> builder)
    {
        builder
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(Authors.Constraints.FirstNameMaxLength);

        builder
             .Property(x => x.LastName)
             .IsRequired()
             .HasMaxLength(Authors.Constraints.LastNameMaxLength);

        builder
         .Property(x => x.Country)
         .IsRequired()
         .HasMaxLength(Authors.Constraints.CountryMaxLength);
    }
}
