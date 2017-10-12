using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implementations.EF.Entities;


namespace Data.Implementations.EF.DataContext
{
    interface IProductCatalogContext
    {
        IDbSet<Category> Categories { get; set; }
        IDbSet<Product> Products { get; set; }
    }
}
