namespace Market.Infrastructure.Database.Configurations.Catalog;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(Author.Constraints.FirstNameMaxLength);

        builder
             .Property(x => x.LastName)
             .IsRequired()
             .HasMaxLength(Author.Constraints.LastNameMaxLength);

        builder
         .Property(x => x.Country)
         .IsRequired()
         .HasMaxLength(Author.Constraints.CountryMaxLength);
    }
}
