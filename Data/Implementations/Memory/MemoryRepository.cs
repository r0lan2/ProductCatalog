﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Dto;
using Data.Implementations.EF.Entities;

namespace Data
{
    public class MemoryRepository:IRepository
    {
        private Dictionary<int, ProductDTO> _products = new Dictionary<int, ProductDTO>();
        private static Dictionary<int, Category> _categories = new Dictionary<int, Category>();

        static MemoryRepository()
        {
            _categories.Add(1, new Category() {CategoryId = 1,Name = "Category A"});
            _categories.Add(2, new Category() { CategoryId = 1, Name = "Category B" });
            _categories.Add(3, new Category() { CategoryId = 1, Name = "Category C" });
            _categories.Add(4, new Category() { CategoryId = 1, Name = "Category D" });
        }

        public List<ProductDTO> GetProducts()
        {
            return _products.Values.ToList();
        }

        public ProductDTO GetProduct(int productId)
        {
            return _products[productId];
        }

        public int StoreProduct(ProductDTO product)
        {
            return product.ProductId > 0 ? InsertNewProduct(product) : UpdateProduct(product);
        }

        private int InsertNewProduct(ProductDTO product)
        {
            var newProductId = _products.Keys.Max() + 1;
            product.ProductId = newProductId;
            _products.Add(newProductId, product);
            return newProductId;
        }


        private int UpdateProduct(ProductDTO product)
        {
            var productToUpdate = GetProduct(product.ProductId);
            productToUpdate.Price = product.Price;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.CategoryName = getCategory(product.CategoryId).Name;
            productToUpdate.Title = product.Title;
            return product.ProductId;
        }

        private static Category getCategory(int categoryId)
        {
            return _categories[categoryId];
        }

        public bool DeleteProduct(int productId)
        {
            return _products.Remove(productId);
        }



    }
}
