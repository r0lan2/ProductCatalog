using System.Data.Entity.ModelConfiguration;

namespace Data.Implementations.EF.Entities
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {

        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductId);

            // Properties
            // Table & Column Mappings
            this.ToTable("product");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");

        }
    }
}
