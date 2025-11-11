namespace Market.Infrastructure.Database.Configurations.Catalog;

public class CategoryConfiguration : IEntityTypeConfiguration<Categories>
{
    public void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Categories.Constraints.NameMaxLength);
    }
}
