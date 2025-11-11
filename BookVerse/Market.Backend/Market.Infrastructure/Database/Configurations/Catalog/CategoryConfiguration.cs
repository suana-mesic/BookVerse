namespace Market.Infrastructure.Database.Configurations.Catalog;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Category.Constraints.NameMaxLength);
    }
}
