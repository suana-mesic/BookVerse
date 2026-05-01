namespace BookVerse.Infrastructure.Database.Configurations.Catalog;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("Languages");
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Language.Constraints.NameMaxLength);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}
