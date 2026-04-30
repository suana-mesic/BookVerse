//using BookVerse.Domain.Common;

//namespace BookVerse.Domain.Entities.Catalog;

///// <summary>
///// Represents a product category.
///// </summary>
//public class ProductCategoryEntity : BaseEntity
//{
//    /// <summary>
//    /// Name of the category.
//    /// </summary>
//    public string Name { get; set; }

//    /// <summary>
//    /// Indicates whether the category is active (enabled).
//    /// </summary>
//    public bool IsEnabled { get; set; }

//    /// <summary>
//    /// List of products belonging to this category.
//    ///
//    /// **Note for students:**
//    /// This collection is used primarily for reading (querying),
//    /// not for modifications. We use <see cref="IReadOnlyCollection{T}"/>
//    /// with <c>private set</c> to prevent direct manipulation
//    /// of the list contents in code (e.g., <c>category.Products.Add(...)</c>).
//    ///
//    /// EF Core can still load products using <c>Include</c>,
//    /// but will not track changes in this collection during
//    /// <c>SaveChanges</c>.
//    ///
//    /// Technically, it is possible to use a regular <see cref="ICollection{T}"/>
//    /// and add products via navigation, but that often brings
//    /// complications:
//    /// - EF Core may lose entity state tracking,
//    /// - it may attempt to create the relation twice,
//    /// - and it complicates validation and business rules (e.g., preventing adding
//    ///   products to a disabled category).
//    ///
//    /// That is why a "read-only" approach is used here: the category knows
//    /// which products are associated with it, but modifications are made exclusively
//    /// through <see cref="ProductEntity"/> which has <c>CategoryId</c>.
//    /// </summary>
//    public IReadOnlyCollection<ProductEntity> Products { get; private set; } = new List<ProductEntity>();

//    /// <summary>
//    /// Single source of truth for technical/business constraints.
//    /// Used in validators and EF configuration.
//    /// </summary>
//    public static class Constraints
//    {
//        public const int NameMaxLength = 100;
//    }
//}