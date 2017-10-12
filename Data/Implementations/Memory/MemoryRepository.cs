using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Dto;

namespace Data
{
    public class MemoryRepository:IRepository
    {
        public List<ProductDTO> GetProducts()
        {
            throw new NotImplementedException();
        }

        public ProductDTO GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public int StoreProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
