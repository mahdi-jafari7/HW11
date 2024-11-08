using HW11.configuration;
using HW11.Entities;
using HW11.Interfaces;
using HW11.Repostitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Services
{
    public class ProductService : IProductService
    {

        IProductRepository _productRepository = new ProductRepository(Configuration.ConnectionString);
        ICategoryRepository _categoryRepository = new CategoryRepository(Configuration.ConnectionString);

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public void AddProduct(string name, decimal price, int categoryId)
        {
            var product = new Product { Name = name, Price = price, CategoryId = categoryId };
            _productRepository.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void UpdateProduct(int id, string name, decimal price, int categoryId)
        {
            var product = _productRepository.GetById(id);
            if (product != null)
            {
                product.Name = name;
                product.Price = price;
                product.CategoryId = categoryId;
                _productRepository.Update(product);
            }
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }
    }

}
