namespace Market.Infrastructure.Database.Configurations.Catelog;

public class BookConfiguration : IEntityTypeConfiguration<Books>
{
    public void Configure(EntityTypeBuilder<Books> builder)
    {
        builder
            .Property(x => x.ISBN)
            .IsRequired()
            .HasMaxLength(Books.Constraints.ISBNMaxLength);

        builder
             .Property(x => x.Title)
             .IsRequired()
             .HasMaxLength(Books.Constraints.TitleMaxLength);

        builder
           .Property(x => x.Language)
           .IsRequired()
           .HasMaxLength(Books.Constraints.LanguageMaxLength);

    }
}
