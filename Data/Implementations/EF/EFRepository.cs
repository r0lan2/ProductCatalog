using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Dto;
using Data.Implementations.EF.DataContext;
using Data.Implementations.EF.Entities;

namespace Data
{
    public class EFRepository:IRepository
    {
        private IProductCatalogContext _context;
        public EFRepository(IProductCatalogContext context)
        {
            _context = context;
        }

       
        public List<ProductDTO> GetProducts()
        {
            var query = (from p in _context.Products
                         join c in _context.Categories on p.CategoryId equals c.CategoryId
                select new ProductDTO
                {
                    ProductId = p.ProductId,
                    CategoryId = p.CategoryId,
                    Title = p.Title,
                    CategoryName = c.Name,
                    Price = p.Price
                }).ToList();

            return query;
        }



        public List<CategoryDTO> GetCategories()
        {
            var query = (from p in _context.Categories
                select new CategoryDTO
                {
                    CategoryId = p.CategoryId,
                    Name = p.Name
                }).ToList();

            return query;
        }

        public ProductDTO GetProduct(int productId)
        {
            var product = (from p in _context.Products
                join c in _context.Categories on p.CategoryId equals c.CategoryId
                           where p.ProductId == productId
                select new ProductDTO
                {
                    ProductId = p.ProductId,
                    CategoryId = p.CategoryId,
                    Title = p.Title,
                    CategoryName = c.Name,
                    Price = p.Price
                }).FirstOrDefault();
            return product;

        }

        public int StoreProduct(ProductDTO product)
        {
            return product.ProductId <= 0 ? InsertNewProduct(product) : UpdateProduct(product);
        }

        private int InsertNewProduct(ProductDTO product)
        {
            var newProduct = new Product()
            {
                CategoryId = product.CategoryId,
                Price = product.Price,
                Title = product.Title
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct.ProductId;
        }

        public int UpdateProduct(ProductDTO product)
        {
            var productToUpdate = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Title = product.Title;
                productToUpdate.Price = product.Price;
                _context.SaveChanges();
            }
            return productToUpdate.ProductId;
        }

        public bool DeleteProduct(int productId)
        {
            var productToDelete = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return true; // change this .. true doesn mean anything for the client side...
        }
    }
}
