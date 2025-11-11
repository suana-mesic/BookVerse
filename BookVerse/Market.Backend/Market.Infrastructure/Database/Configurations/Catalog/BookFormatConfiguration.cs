namespace Market.Infrastructure.Database.Configurations.Catalog;

public class BookFormatConfiguration : IEntityTypeConfiguration<BookFormats>
{
    public void Configure(EntityTypeBuilder<BookFormats> builder)
    {
        builder.ToTable("BookFormats");
        builder
            .Property(x => x.Format)
            .IsRequired()
            .HasMaxLength(BookFormats.Constraints.FormatMaxLength);

    }
}
