using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implementations.EF.Entities;

namespace Data.Implementations.EF.DataContext
{
    public class ProductCatalogContext: DbContext, IProductCatalogContext
    {
        static ProductCatalogContext()
        {
            Database.SetInitializer<ProductCatalogContext>(null);
        }

        public  ProductCatalogContext(string conString)
            : base(conString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }


        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Product> Products { get; set; }


    }
}
