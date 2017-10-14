using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Dto;

namespace Data
{
    public interface IRepository
    {
        List<ProductDTO> GetProducts();
        ProductDTO GetProduct(int productId);
        int StoreProduct(ProductDTO product);
        bool DeleteProduct(int productId);

        List<CategoryDTO> GetCategories();
    }
}
