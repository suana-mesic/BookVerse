namespace Market.Infrastructure.Database.Configurations.Catalog;

public class BookFormatConfiguration : IEntityTypeConfiguration<BookFormat>
{
    public void Configure(EntityTypeBuilder<BookFormat> builder)
    {
        builder.ToTable("BookFormats");
        builder
            .Property(x => x.Format)
            .IsRequired()
            .HasMaxLength(BookFormat.Constraints.FormatMaxLength);

    }
}
