namespace BookVerse.Infrastructure.Database.Configurations.Catalog;

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
            .HasOne(x => x.Language)
            .WithMany(l => l.Books)
            .HasForeignKey(x => x.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
