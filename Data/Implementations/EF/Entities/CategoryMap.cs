using System.Data.Entity.ModelConfiguration;

namespace Data.Implementations.EF.Entities
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryId);

            // Properties
            // Table & Column Mappings
            this.ToTable("category");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.Name).HasColumnName("Name");
       
        }
    }
}
